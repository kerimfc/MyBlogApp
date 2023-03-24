using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.DTOs
{
    public class ArticleWidthHtmlDto : ArticleDto
    {
        public string HtmlContent { get; set; }

        public string ContentUrl { get; set; }
    }
}
