﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1 , Name = "Asp.NET", CreatedDate = DateTime.Now},
                new Category { Id = 2, Name = ".NET Core", CreatedDate = DateTime.Now },
                new Category { Id = 3, Name = "MsSQL" , CreatedDate = DateTime.Now },
                new Category { Id = 4, Name = "Web API" , CreatedDate = DateTime.Now },
                new Category { Id = 5, Name = "React Js" , CreatedDate = DateTime.Now });
        }
    }
}
