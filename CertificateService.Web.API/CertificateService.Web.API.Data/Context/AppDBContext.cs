using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CertificateService.Web.API.Data.Context
{
    /// <summary>
    /// DB context for Certificate Web API.
    /// </summary>
    public class AppDBContext : DbContext
    {
        /// <summary>
        /// Gets or sets <see cref="DbSet{Student}"/>.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{StudentData}"/>.
        /// </summary>
        public DbSet<StudentData> StudentDatas { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{StudentTicket}"/>.
        /// </summary>
        public DbSet<StudentTicket> StudentTickets { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{Group}"/>.
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{Faculty}"/>.
        /// </summary>
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{User}"/>.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDBContext"/> class.
        /// </summary>
        /// <param name="options"><see cref="DbContextOptions{AppDBContext}"/>.</param>
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
