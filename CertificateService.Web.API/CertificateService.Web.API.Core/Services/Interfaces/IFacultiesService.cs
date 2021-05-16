using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IFacultiesService
    {
        Task AddAsync(AddFacultyViewModel newFaculty);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateFacultyViewModel faculty);
        Task<IEnumerable<Faculty>> GetFacultiesAsync();
        Task<Faculty> GetFacultyAsync(int id);
        Task<Faculty> GetFacultyByNumberAsync(int number);
        Task AddGroupsToFacultyAsync(int facultyId, int[] groupIds);
        Task RemoveGroupsFromFacultyAsync(int facultyId, int[] groupIds);
    }
}
