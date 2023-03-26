using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetSingleCategoryByIdWidthArticles(int categoryId)
        {
            return await _context.Categories.Include(x=>x.Articles).Where(x=>x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
