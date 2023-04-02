using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.Core.DTOs;
using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using MyBlog.Core.Services;
using MyBlog.Core.UnitOfWorks;
using MyBlog.Repository.Repositories;
using MyBlog.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Caching
{
    public class CategoryServiceWithCaching : ICategoryService
    {
        private const string CacheCategoryKey = "categoryCache";

        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServiceWithCaching(IMemoryCache memoryCache,
            IMapper mapper, ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheCategoryKey, out _))
            {
                _memoryCache.Set(CacheCategoryKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Category> AddAsync(Category entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            await CacheAllCategoryAsync();

            return entity;
        }

        public async Task<IEnumerable<Category>> AddRangeAsync(IEnumerable<Category> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            await CacheAllCategoryAsync();

            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Category>>(CacheCategoryKey));
        }

        public Task<Category> GetByIdAsync(int id)
        {
            var category = _memoryCache.Get<List<Category>>(CacheCategoryKey).FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                throw new NotFoundException($"{typeof(Category).Name}({id}) not found!");
            }

            return Task.FromResult(category);
        }

        public Task<Category> GetByNameAsync(string name)
        {
            var category = _memoryCache.Get<List<Category>>(CacheCategoryKey).FirstOrDefault(x => x.Name == name);

            if (category == null)
            {
                throw new NotFoundException($"{typeof(Category).Name}({name}) not found!");
            }

            return Task.FromResult(category);
        }

        public Task<CustomResponseDto<CategoryWidthArticlesDto>> GetSingleCategoryByIdWidthArticles(int categoryId)
        {
            var category = _memoryCache.Get<List<Category>>(CacheCategoryKey).FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
            {
                throw new NotFoundException($"{typeof(Category).Name}({categoryId}) not found!");
            }

            var categoryDto = _mapper.Map<CategoryWidthArticlesDto>(category);


            return Task.FromResult(CustomResponseDto<CategoryWidthArticlesDto>.Success(200, categoryDto));
        }

        public async Task RemoveAsync(Category entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();

            await CacheAllCategoryAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoryAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoryAsync();
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return _memoryCache.Get<List<Category>>(CacheCategoryKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCategoryAsync()
        {
            _memoryCache.Set(CacheCategoryKey, await _repository.GetAll().ToListAsync());
        }
    }
}
