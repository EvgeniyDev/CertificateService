using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.ViewModels
{
    /// <summary>
    /// A view model for <see cref="Group"/> adding.
    /// </summary>
    public class AddGroupViewModel
    {
        /// <summary>
        /// Gets or sets group's name.
        /// </summary>
        public string Name { get; set; }
    }
}
