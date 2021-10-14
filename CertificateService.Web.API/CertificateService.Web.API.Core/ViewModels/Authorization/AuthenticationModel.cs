using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Core.ViewModels.Authorization
{
    /// <summary>
    /// A model for user authentication.
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
