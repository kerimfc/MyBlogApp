using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Core.DTOs;
using MyBlog.Core.Models;
using MyBlog.Core.Services;
using MyBlog.Service.Exceptions;

namespace MyBlog.API.Filter
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var IdValue = context.ActionArguments.Values.FirstOrDefault();

            if (IdValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)IdValue;

            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not Found"));
        }
    }
}
