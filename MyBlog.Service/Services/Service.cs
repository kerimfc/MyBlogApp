using Microsoft.EntityFrameworkCore;
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

namespace MyBlog.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var hasValue = await _repository.GetAll().ToListAsync();

            if (hasValue == null)
            {
                throw new NotFoundException($"{typeof(T).Name} not found");
            }

            return hasValue;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasValue = await _repository.GetByIdAsync(id);

            if(hasValue == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({id}) not found");
            }

            return hasValue;
        }

        public async Task<T> GetByNameAsync(string name)
        {
            var hasValue = await _repository.GetByNameAsync(name);

            if (hasValue == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({name}) not found");
            }

            return hasValue;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            var hasValue = _repository.Where(expression);


            if (hasValue == null)
            {
                throw new NotFoundException($"{typeof(T).Name} not found");
            }

            return hasValue;
        }
    }
}
