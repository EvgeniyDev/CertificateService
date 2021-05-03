using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupRepository groupRepository;

        public GroupsService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public void Add(Group newGroup)
        {
            groupRepository.Add(newGroup);
        }

        public void Delete(int id)
        {
            groupRepository.Delete(id);
        }

        public Group GetGroup(int id)
        {
            return groupRepository.GetGroupById(id);
        }

        public IEnumerable<Group> GetGroups()
        {
            return groupRepository.GetGroups();
        }

        public void Update(Group group)
        {
            groupRepository.Update(group);
        }
    }
}
