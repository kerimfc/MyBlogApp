using MyBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.DTOs
{
    public class CategoryWidthArticlesDto : CategoryDto
    {
        public ICollection<ArticleDto> Articles { get; set; }

        public ICollection<ArticleWidthHtmlDto> ArticlesWidthHtml { get; set; }

    }
}
