using FluentValidation;
using FluentValidation.AspNetCore;
using MyBlog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Validations
{
    public class ArticleDtoValidator : AbstractValidator<ArticleDto>
    {
        public ArticleDtoValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.Title)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Rate)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .InclusiveBetween(0, 100)
                .WithMessage("{PropertyName} must be 0-100");

            RuleFor(x => x.ReadCount)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .InclusiveBetween(0, int.MaxValue)
                .WithMessage("{PropertyName} must be 0-MAX");
        }
    }
}
