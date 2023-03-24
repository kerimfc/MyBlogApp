using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string HtmlContent { get; set; }

        public string ContentUrl { get; set; }

        public int ReadCount { get; set; }

        public decimal Rate { get; set; }

        public string? ArticleImage { get; set; }

        public int PageId { get; set; }

        public int CategoryId { get; set; }

        public Page Page { get; set; }

        public Category Category { get; set; }
    }
}
