using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using MyBlog.Core.Services;
using MyBlog.Core.UnitOfWorks;
using MyBlog.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Caching
{
    public class ArticleServiceWithCaching : IArticleService
    {
        private const string CacheArticleKey = "articleCache";

        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleServiceWithCaching(IMemoryCache memoryCache, 
            IMapper mapper, IArticleRepository repository, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheArticleKey, out _))
            {
                _memoryCache.Set(CacheArticleKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Article> AddAsync(Article entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            await CacheAllCategoryAsync();

            return entity;
        }

        public async Task<IEnumerable<Article>> AddRangeAsync(IEnumerable<Article> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            await CacheAllCategoryAsync();

            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Article, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Article>>(CacheArticleKey));
        }

        public Task<Article> GetByIdAsync(int id)
        {
            var article = _memoryCache.Get<List<Article>>(CacheArticleKey).FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                throw new NotFoundException($"{typeof(Article).Name}({id}) not found!");
            }

            return Task.FromResult(article);
        }

        public Task<Article> GetByNameAsync(string name)
        {
            var article = _memoryCache.Get<List<Article>>(CacheArticleKey).FirstOrDefault(x => x.Title.Contains(name));

            if (article == null)
            {
                throw new NotFoundException($"{typeof(Article).Name}({name}) not found!");
            }

            return Task.FromResult(article);
        }

        public async Task RemoveAsync(Article entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoryAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Article> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoryAsync();
        }

        public async Task UpdateAsync(Article entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoryAsync();
        }

        public IQueryable<Article> Where(Expression<Func<Article, bool>> expression)
        {
            return _memoryCache.Get<List<Article>>(CacheArticleKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCategoryAsync()
        {
            _memoryCache.Set(CacheArticleKey, await _repository.GetAll().ToListAsync());
        }
    }
}
