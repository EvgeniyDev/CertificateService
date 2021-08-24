using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    public class StudentTicketConfiguration : IEntityTypeConfiguration<StudentTicket>
    {
        public void Configure(EntityTypeBuilder<StudentTicket> builder)
        {
            builder.Property(st => st.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(st => st.Number)
                .IsRequired();

            builder.Property(st => st.DateOfIssue)
                .IsRequired();

            builder.Property(st => st.DateOfExpiry)
                .IsRequired();

            builder.HasIndex(st => st.Number)
                .IsUnique();
        }
    }
}
