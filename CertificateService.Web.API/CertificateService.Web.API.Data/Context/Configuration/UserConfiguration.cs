using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    /// <summary>
    /// Configuration of table in DB related to <see cref="User"/>.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Sets configration for table in DB related to <see cref="User"/>.
        /// </summary>
        /// <param name="builder"><see cref="EntityTypeBuilder{User}"/>.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.Username)
                .IsRequired();
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.Role)
                .IsRequired();

            builder.HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
