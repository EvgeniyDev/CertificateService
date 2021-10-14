using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.ViewModels
{
    /// <summary>
    /// A view model for <see cref="Group"/> updating.
    /// </summary>
    public class UpdateGroupViewModel
    {
        /// <summary>
        /// Gets or sets group's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets group's name.
        /// </summary>
        public string Name { get; set; }
    }
}
