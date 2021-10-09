namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing the user of the API.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets user's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user's role.
        /// </summary>
        public string Role { get; set; }
    }
}
