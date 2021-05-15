using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IGroupsService
    {
        void Add(AddGroupViewModel newGroup);
        void Delete(int id);
        void Update(UpdateGroupViewModel group);
        IEnumerable<Group> GetGroups();
        Group GetGroup(int id);
        Group GetGroup(string groupName);
        void AddStudentsToGroup(int groupId, int[] studentIds);
        void RemoveStudentsFromGroup(int groupId, int[] studentIds);
    }
}
