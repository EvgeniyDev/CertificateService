using System.IO;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for the issuance of certificates.
    /// </summary>
    public interface ICertificatesService
    {
        /// <summary>
        /// Gets a byte stream representing certificate data.
        /// </summary>
        /// <param name="studentId">A student's id to issue certificate for.</param>
        /// <param name="isPdf">A value indicating whether the output will be in PDF or DOCX format.</param>
        /// <returns>A <see cref="Task{Stream}"/> that contains data about the certificate.</returns>
        Task<Stream> GetCertificateAsync(int studentId, bool isPdf);
    }
}
