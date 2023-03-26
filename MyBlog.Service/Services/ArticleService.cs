using AutoMapper;
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
    public class ArticleService : Service<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork, IArticleRepository articleRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
    }
}
