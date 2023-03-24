using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.DTOs
{
    public class PageWidthArticles : PageDto
    {
        public ICollection<ArticleDto> Articles { get; set; }

    }
}
