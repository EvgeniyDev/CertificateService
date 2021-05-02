using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        public IEnumerable<Group> GetGroups();
        public Group GetGroupById(int id);
        public Group GetGroupByName(string name);
        public void Add(Group newGroup);
        public void Update(Group group);
        public void Delete(int id);
        public void Save();
    }
}
