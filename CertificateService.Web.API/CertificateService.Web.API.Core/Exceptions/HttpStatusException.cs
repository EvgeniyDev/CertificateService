using System;
using System.Net;

namespace CertificateService.Web.API.Core.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpStatusException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
