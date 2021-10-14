using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for generating JWT tokens.
    /// </summary>
    public interface IJwtTokenProviderService
    {
        /// <summary>
        /// Generates new JWT Bearer token.
        /// </summary>
        /// <param name="user">A <see cref="User"/> to generate Bearer token for.</param>
        /// <returns>JWT token in string format.</returns>
        string CreateToken(User user);
    }
}
