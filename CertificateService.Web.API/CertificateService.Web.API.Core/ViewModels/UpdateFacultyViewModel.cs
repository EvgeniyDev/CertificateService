using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.ViewModels
{
    /// <summary>
    /// A view model for <see cref="Faculty"/> updating.
    /// </summary>
    public class UpdateFacultyViewModel
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
    }
}
