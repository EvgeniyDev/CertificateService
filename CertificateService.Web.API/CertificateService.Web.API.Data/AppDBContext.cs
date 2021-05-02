using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CertificateService.Web.API.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentData> StudentDatas { get; set; }
        public DbSet<StudentTicket> StudentTickets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
