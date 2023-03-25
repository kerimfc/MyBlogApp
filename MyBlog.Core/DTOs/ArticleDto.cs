using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.DTOs
{
    public class ArticleDto : BaseDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int ReadCount { get; set; }

        public decimal Rate { get; set; }

        public string? ArticleImage { get; set; }

        public int CategoryId { get; set; }
    }
}
