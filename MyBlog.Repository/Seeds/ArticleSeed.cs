using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Seeds
{
    internal class ArticleSeed : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new Article
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Makale 1",
                    Content = "Makale 1 Content 1",
                    ContentUrl = "/Makale1",
                    HtmlContent = "",
                    Rate = 0,
                    ReadCount = 0,
                    CreatedDate = DateTime.Now
                });

            builder.HasData(
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "Makale 2",
                    Content = "Makale 2 Content 2",
                    ContentUrl = "/Makale2",
                    HtmlContent = "",
                    Rate = 0,
                    ReadCount = 0,
                    CreatedDate = DateTime.Now
                });

            builder.HasData(
                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Makale 3",
                    Content = "Makale 3 Content 3",
                    ContentUrl = "/Makale3",
                    HtmlContent = "",
                    Rate = 0,
                    ReadCount = 0,
                    CreatedDate = DateTime.Now
                });
        }
    }
}
