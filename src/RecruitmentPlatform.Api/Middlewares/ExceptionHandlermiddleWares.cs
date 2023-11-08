using Microsoft.AspNetCore.Diagnostics;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.Exceptions;

namespace RecruitmentPlatform.Api.Middlewares
{
    public class ExceptionHandlermiddleWares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlermiddleWares(RequestDelegate next, ILogger<ExceptionHandlermiddleWares> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecruitmentException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                this._logger.LogError($"{ex}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = ex.Message,
                });
            }
        }
    }
}
