using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IJwtTokenProviderService
    {
        string CreateToken(User user);
    }
}
