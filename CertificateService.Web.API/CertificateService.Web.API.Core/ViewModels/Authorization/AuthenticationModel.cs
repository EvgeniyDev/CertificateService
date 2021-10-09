using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Core.ViewModels.Authorization
{
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
