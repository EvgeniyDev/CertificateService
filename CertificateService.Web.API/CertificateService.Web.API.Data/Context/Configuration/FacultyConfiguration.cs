using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
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
