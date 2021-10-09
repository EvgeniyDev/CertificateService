using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    /// <summary>
    /// Configuration of table in DB related to <see cref="Faculty"/>.
    /// </summary>
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        /// <summary>
        /// Sets configration for table in DB related to <see cref="Faculty"/>.
        /// </summary>
        /// <param name="builder"><see cref="EntityTypeBuilder{Faculty}"/>.</param>
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(g => g.Name)
                .IsRequired();

            builder.Property(g => g.Number)
                .IsRequired();
        }
    }
}
