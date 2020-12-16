using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ToddDemo.Application.Extensions;

namespace ToddDemo.Extensions
{
    /// <summary>
    /// 自定义异常中间件
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("业务异常：{0}", ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // 在 Features 里面获取异常
            //var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();

            // 1.识别异常是否为业务异常(IKnownException）
            IKnownException knownException = ex as IKnownException;

            // 2.为空系统异常，否则业务异常
            if (knownException == null)
            {
                knownException = KnownException.UnKnown;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else
            {
                knownException = KnownException.FromKnownException(knownException);
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            // 3.把响应信息通过json 的方式输出出去
            httpContext.Response.ContentType = "application/json; charset=utf-8";
            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(knownException));
        }
    }

    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
