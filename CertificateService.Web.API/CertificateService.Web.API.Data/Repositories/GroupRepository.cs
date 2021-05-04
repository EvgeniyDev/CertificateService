using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return appDBContext.Groups
                .Include(g => g.Students)
                .FirstOrDefault(x => x.Id == id);
        }

        public Group GetGroupByName(string name)
        {
            return appDBContext.Groups
                .Include(g => g.Students)
                .FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Group> GetGroups()
        {
            return appDBContext.Groups
                .Include(g => g.Students).ThenInclude(s => s.StudentData)
                .Include(g => g.Students).ThenInclude(s => s.StudentTicket)
                .AsNoTracking();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Group group)
        {
            appDBContext.Update(group);
            Save();
        }
    }
}
