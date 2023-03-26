using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Core.DTOs;
using MyBlog.Core.Models;

namespace MyBlog.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWidthArticlesDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<Article, ArticleWidthHtmlDto>().ReverseMap();
            CreateMap<Page, PageDto>().ReverseMap();
        }
    }
}
