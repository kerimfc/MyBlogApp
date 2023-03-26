using AutoMapper;
using MyBlog.Core.DTOs;
using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using MyBlog.Core.Services;
using MyBlog.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWidthArticlesDto>> GetSingleCategoryByIdWidthArticles(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWidthArticles(categoryId);

            var categoryDto = _mapper.Map<CategoryWidthArticlesDto>(category);

            return CustomResponseDto<CategoryWidthArticlesDto>.Success(200, categoryDto);
        }
    }
}
