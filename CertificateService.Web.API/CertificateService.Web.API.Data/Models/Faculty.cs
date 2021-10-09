using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing the faculty of the university.
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// Gets or sets faculty's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets faculty's number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets faculty's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <see cref="ICollection{Group}"/>.
        /// </summary>
        public ICollection<Group> Groups { get; set; }
    }
}
