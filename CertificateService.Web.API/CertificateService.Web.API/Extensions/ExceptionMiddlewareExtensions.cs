using CertificateService.Web.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CertificateService.Web.API.Extensions
{
    /// <summary>
    /// An extensions for <see cref="ExceptionMiddleware"/>.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds exception handling middleware.
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/>.</param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
