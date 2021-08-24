using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CertificateService.Web.API.Data.Context
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
