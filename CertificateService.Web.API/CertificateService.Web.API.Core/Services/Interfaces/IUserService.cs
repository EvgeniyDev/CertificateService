using CertificateService.Web.API.Core.ViewModels.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Authenticate(string username, string password);
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
    }
}
