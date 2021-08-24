using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    public class StudentDataConfiguration : IEntityTypeConfiguration<StudentData>
    {
        public void Configure(EntityTypeBuilder<StudentData> builder)
        {
            builder.Property(sd => sd.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(sd => sd.Name)
                .IsRequired();

            builder.Property(sd => sd.Surname)
                .IsRequired();

            builder.Property(sd => sd.Patronymic)
                .IsRequired();

            builder.Property(sd => sd.DateOfBirth)
                .IsRequired();

            builder.Property(sd => sd.Gender)
                .IsRequired();

            builder.HasIndex(sd => new { sd.Name, sd.Surname, sd.Patronymic, sd.Gender, sd.DateOfBirth})
                .IsUnique();
        }
    }
}
