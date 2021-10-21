using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    /// <summary>
    /// A controller for certificate manipulations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Role.Admin)]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificatesService certificatesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateController"/> class.
        /// </summary>
        /// <param name="certificatesService"><see cref="ICertificatesService"/>.</param>
        public CertificateController(ICertificatesService certificatesService)
        {
            this.certificatesService = certificatesService;
        }

        /// <summary>
        /// Gets the certificate by student id in specified format.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <param name="isPdf">A values indicating where the file is in PDF or DOCX format.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCertificate(int studentId, bool isPdf)
        {
            var result = await certificatesService.GetCertificateAsync(studentId, isPdf);
            var fileName = isPdf ? Constants.OutputData.FileNamePdf : Constants.OutputData.FileNameDocx;

            return File(result, Constants.OutputData.ContentType, fileName);
        }
    }
}
