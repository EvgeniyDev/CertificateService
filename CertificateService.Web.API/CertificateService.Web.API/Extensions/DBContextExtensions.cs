using CertificateService.Web.API.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CertificateService.Web.API.Extensions
{
    /// <summary>
    /// An extensions for <see cref="AppDBContext"/>.
    /// </summary>
    public static class DBContextExtensions
    {
        /// <summary>
        /// Ensures migrations applied.
        /// </summary>
        /// <typeparam name="T"><see cref="AppDBContext"/>.</typeparam>
        /// <param name="app"><see cref="IApplicationBuilder"/>.</param>
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : AppDBContext
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var context = (T)serviceScope.ServiceProvider.GetService(typeof(T));
            context.Database.Migrate();
        }
    }
}
