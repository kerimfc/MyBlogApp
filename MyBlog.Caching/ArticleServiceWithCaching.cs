using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using MyBlog.Core.Services;
using MyBlog.Core.UnitOfWorks;
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

        public Task<Article> AddAsync(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> AddRangeAsync(IEnumerable<Article> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Article, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Article> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Article entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> Where(Expression<Func<Article, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
