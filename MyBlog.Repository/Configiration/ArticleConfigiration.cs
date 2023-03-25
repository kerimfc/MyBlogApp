using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Configiration
{
    public class ArticleConfigiration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.Property(x => x.Content).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.ContentUrl).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.HtmlContent).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ArticleImage).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.ReadCount).IsRequired();
            builder.ToTable("Articles");

            builder.HasOne(x => x.Category)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.CategoryId);         }
    }
}
