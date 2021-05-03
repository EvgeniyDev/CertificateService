using CertificateService.Web.API.Core.Exceptions;
using CertificateService.Web.API.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CertificateService.Web.API.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusException exception)
        {
            context.Response.StatusCode = (int)exception.StatusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
