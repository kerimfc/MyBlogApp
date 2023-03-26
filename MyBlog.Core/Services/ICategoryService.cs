using MyBlog.Core.DTOs;
using MyBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWidthArticlesDto>> GetSingleCategoryByIdWidthArticles(int categoryId);
    }
}
