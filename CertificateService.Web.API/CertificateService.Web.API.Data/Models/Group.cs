using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing the group of the faculty.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets group's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets group's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <see cref="ICollection{Student}"/>.
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }
}
