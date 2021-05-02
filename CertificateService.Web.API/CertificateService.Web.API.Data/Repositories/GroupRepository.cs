using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDBContext appDBContext;

        public GroupRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(Group newGroup)
        {
            newGroup.Id = default;

            appDBContext.Groups.Add(newGroup);
            Save();
        }

        public void Delete(int id)
        {
            var groupToDelete = GetGroupById(id);

            if (groupToDelete != null)
            {
                appDBContext.Groups.Remove(groupToDelete);
                Save();
            }
        }

        public Group GetGroupById(int id)
        {
            return appDBContext.Groups.FirstOrDefault(x => x.Id == id);
        }

        public Group GetGroupByName(string name)
        {
            return appDBContext.Groups.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Group> GetGroups()
        {
            return appDBContext.Groups.AsEnumerable();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Group group)
        {
            var groupToUpdate = GetGroupById(group.Id);

            if (groupToUpdate is null)
            {
                Add(group);
            }
            else
            {
                groupToUpdate.Name = group.Name;

                appDBContext.Update(groupToUpdate);
            }

            Save();
        }
    }
}
