using System;
using System.Net;

namespace CertificateService.Web.API.Core.Exceptions
{
    /// <summary>
    /// Custom status code exception.
    /// </summary>
    public class HttpStatusException : Exception
    {
        /// <summary>
        /// Gets exception's status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpStatusException"/> class.
        /// </summary>
        /// <param name="statusCode"><see cref="HttpStatusCode"/>.</param>
        /// <param name="message">Exception's message.</param>
        public HttpStatusException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
