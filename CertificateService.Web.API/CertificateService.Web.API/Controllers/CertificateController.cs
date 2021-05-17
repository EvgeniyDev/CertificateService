using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificatesService certificatesService;

        public CertificateController(ICertificatesService certificatesService)
        {
            this.certificatesService = certificatesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCertificate(int studentId, bool isPdf)
        {
            var result = await certificatesService.GetCertificateAsync(studentId, isPdf);
            var fileName = isPdf ? Constants.OutputData.FileNamePdf : Constants.OutputData.FileNameDocx;

            return File(result, Constants.OutputData.ContentType, fileName);
        }
    }
}
