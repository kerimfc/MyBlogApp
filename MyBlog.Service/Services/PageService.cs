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
    public class PageService : Service<Page>, IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;
        public PageService(IGenericRepository<Page> repository, IUnitOfWork unitOfWork, IPageRepository pageRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
        }
    }
}
