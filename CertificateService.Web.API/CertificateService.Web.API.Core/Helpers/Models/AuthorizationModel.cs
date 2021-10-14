namespace CertificateService.Web.API.Core.Helpers.Models
{
    /// <summary>
    /// Appsettings configuration authorization model.
    /// </summary>
    public class AuthorizationModel
    {
        /// <summary>
        /// Gets or sets client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes after which the token will expire.
        /// </summary>
        public int MinutesTokenExpireIn { get; set; }
    }
}
