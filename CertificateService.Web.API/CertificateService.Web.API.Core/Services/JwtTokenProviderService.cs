using CertificateService.Web.API.Core.Helpers.Models;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CertificateService.Web.API.Core.Services
{
    /// <inheritdoc cref="IJwtTokenProviderService"/>
    public class JwtTokenProviderService : IJwtTokenProviderService
    {
        private const string TokenType = "Bearer ";
        private readonly AuthorizationModel authorizationModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenProviderService"/> class.
        /// </summary>
        /// <param name="authorizationModel">A model representing authorization data.</param>
        public JwtTokenProviderService(IOptions<AuthorizationModel> authorizationModel)
        {
            this.authorizationModel = authorizationModel.Value;
        }

        /// <inheritdoc/>
        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authorizationModel.ClientSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(authorizationModel.MinutesTokenExpireIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return TokenType + tokenHandler.WriteToken(token);
        }
    }
}
