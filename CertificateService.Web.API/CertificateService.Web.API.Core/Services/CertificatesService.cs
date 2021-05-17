using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services
{
    public class CertificatesService : ICertificatesService
    {
        private readonly string certificateFilePath;

        private readonly IStudentsService studentsService;

        public CertificatesService(IStudentsService studentsService, IOptions<CertificateViewModel> options)
        {
            this.studentsService = studentsService;

            certificateFilePath = options.Value.FilePath;
        }

        public async Task<Stream> GetCertificateAsync(int studentId, bool isPdf)
        {
            var student = await studentsService.GetStudentAsync(studentId);

            var fileStream = new FileStream(certificateFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStream;
        }
    }
}
