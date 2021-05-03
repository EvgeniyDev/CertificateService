using AutoMapper;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IMapper mapper;
        private readonly IGroupRepository groupRepository;

        public GroupsService(IGroupRepository groupRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.groupRepository = groupRepository;
        }

        public void Add(AddGroupViewModel newGroup)
        {
            var groupToAdd = mapper.Map<Group>(newGroup);
            groupRepository.Add(groupToAdd);
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

        public void Update(UpdateGroupViewModel group)
        {
            var groupToUpdate = mapper.Map<Group>(group);

            groupRepository.Update(groupToUpdate);
        }
    }
}
