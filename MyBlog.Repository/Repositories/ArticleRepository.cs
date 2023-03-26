using MyBlog.Core.Models;
using MyBlog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
