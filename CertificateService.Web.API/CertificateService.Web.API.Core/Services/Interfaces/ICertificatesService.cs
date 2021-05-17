using System.IO;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface ICertificatesService
    {
        Task<Stream> GetCertificateAsync(int studentId, bool isPdf);
    }
}
