using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.ViewModels.Authorization
{
    public class UserViewModel : User
    {
        public string Token { get; set; }
    }
}
