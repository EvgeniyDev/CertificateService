using CertificateService.Web.API.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CertificateService.Web.API.Extensions
{
    public static class DBContextExtensions
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : AppDBContext
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var context = (T)serviceScope.ServiceProvider.GetService(typeof(T));
            context.Database.Migrate();
        }
    }
}
