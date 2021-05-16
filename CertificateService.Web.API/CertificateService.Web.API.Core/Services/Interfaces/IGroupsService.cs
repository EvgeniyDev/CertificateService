using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IGroupsService
    {
        Task AddAsync(AddGroupViewModel newGroup);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateGroupViewModel group);
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Group> GetGroupAsync(int id);
        Task<Group> GetGroupAsync(string groupName);
        Task AddStudentsToGroupAsync(int groupId, int[] studentIds);
        Task RemoveStudentsFromGroupAsync(int groupId, int[] studentIds);
    }
}
