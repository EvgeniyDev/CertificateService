namespace CertificateService.Web.API.Core.Helpers.Models
{
    public class AuthorizationModel
    {
        public string ClientSecret { get; set; }
        public int MinutesTokenExpireIn { get; set; }
    }
}
