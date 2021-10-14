using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.ViewModels.Authorization
{
    /// <inheritdoc/>
    public class UserViewModel : User
    {
        /// <summary>
        /// Gets or sets user token.
        /// </summary>
        public string Token { get; set; }
    }
}
