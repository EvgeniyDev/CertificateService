using Microsoft.EntityFrameworkCore;

namespace CertificateService.Web.API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
