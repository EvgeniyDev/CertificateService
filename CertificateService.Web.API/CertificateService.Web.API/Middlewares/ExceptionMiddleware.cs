using CertificateService.Web.API.Core.Exceptions;
using CertificateService.Web.API.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Middlewares
{
    /// <summary>
    /// A custom exception handling middleware.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/>.</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Wraps request delegate call with try-catch block and invokes it.
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
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
