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
    internal class PageSeed : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasData(
                new Page { Id = 1, Title = "Home"},
                new Page { Id = 2, Title = "Articles" },
                new Page { Id = 3, Title = "About" },
                new Page { Id = 4, Title = "Contact" },
                new Page { Id = 5, Title = "Projects" });
        }
    }
}
