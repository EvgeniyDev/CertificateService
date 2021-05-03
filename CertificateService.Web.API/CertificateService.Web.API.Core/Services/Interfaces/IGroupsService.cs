using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IGroupsService
    {
        void Add(Group newGroup);
        void Delete(int id);
        void Update(Group group);
        IEnumerable<Group> GetGroups();
        Group GetGroup(int id);
    }
}
