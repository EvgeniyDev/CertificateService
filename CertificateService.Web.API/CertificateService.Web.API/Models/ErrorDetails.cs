using Newtonsoft.Json;

namespace CertificateService.Web.API.Models
{
    /// <summary>
    /// A model for custom error response.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Gets or sets error status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Serializes object to json string.
        /// </summary>
        /// <returns>A json string of this object.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
