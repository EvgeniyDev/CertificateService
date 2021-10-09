using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    /// <summary>
    /// Configuration of table in DB related to <see cref="Student"/>.
    /// </summary>
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// Sets configration for table in DB related to <see cref="Student"/>.
        /// </summary>
        /// <param name="builder"><see cref="EntityTypeBuilder{Student}"/>.</param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
