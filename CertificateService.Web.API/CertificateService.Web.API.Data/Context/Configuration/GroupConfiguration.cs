using CertificateService.Web.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificateService.Web.API.Data.Context.Configuration
{
    /// <summary>
    /// Configuration of table in DB related to <see cref="Group"/>.
    /// </summary>
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        /// <summary>
        /// Sets configration for table in DB related to <see cref="Group"/>.
        /// </summary>
        /// <param name="builder"><see cref="EntityTypeBuilder{Group}"/>.</param>
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(g => g.Name)
                .IsRequired();
        }
    }
}
