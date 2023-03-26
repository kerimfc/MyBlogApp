using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.DTOs;
using MyBlog.Core.Services;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesControllers : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesControllers(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdArticles(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWidthArticles(categoryId));   
        }
    }
}
