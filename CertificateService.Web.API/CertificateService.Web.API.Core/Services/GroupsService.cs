using AutoMapper;
using CertificateService.Web.API.Core.Exceptions;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using CertificateService.Web.API.Data.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;

namespace CertificateService.Web.API.Core.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly ResourceManager resourceManager;

        private readonly IMapper mapper;
        private readonly IGroupRepository groupRepository;
        private readonly IStudentRepository studentsRepository;

        public GroupsService(
            IGroupRepository groupRepository,
            IStudentRepository studentsRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.groupRepository = groupRepository;
            this.studentsRepository = studentsRepository;

            resourceManager = new ResourceManager(typeof(ErrorMessages).FullName, typeof(ErrorMessages).Assembly);
        }

        public void Add(AddGroupViewModel newGroup)
        {
            var groupToAdd = mapper.Map<Group>(newGroup);
            groupRepository.Add(groupToAdd);
        }

        public void Delete(int id)
        {
            GetGroup(id);

            groupRepository.Delete(id);
        }

        public Group GetGroup(int id)
        {
            var group = groupRepository.GetGroupById(id);

            if (group == null)
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), $"Group by requested id [{id}] was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return group;
        }

        public IEnumerable<Group> GetGroups()
        {
            var groups = groupRepository.GetGroups();

            if (!groups.Any())
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), "Groups were");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return groups;
        }

        public void Update(UpdateGroupViewModel group)
        {
            GetGroup(group.Id);

            var groupToUpdate = mapper.Map<Group>(group);
            groupRepository.Update(groupToUpdate);
        }

        public void AddStudentsToGroup(int groupId, int[] studentIds)
        {
            var group = GetGroup(groupId);
            var students = new List<Student>();

            foreach (var studentId in studentIds)
            {
                var studentToAdd = studentsRepository.GetStudentById(studentId);

                if (studentToAdd == null)
                {
                    var errorMessage = string.Format(resourceManager.GetString("NotFound"), $"Student by requested id [{studentId}] was");
                    throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
                }

                students.Add(studentToAdd);
            }

            foreach (var student in students)
            {
                if (!group.Students.Any(x => x.Id == group.Id))
                {
                    group.Students.Add(student);
                }
            }

            groupRepository.Save();
        }

        public void RemoveStudentsFromGroup(int groupId, int[] studentIds)
        {
            var group = GetGroup(groupId);
            var students = new List<Student>();

            foreach (var studentId in studentIds)
            {
                var studentToAdd = studentsRepository.GetStudentById(studentId);

                if (studentToAdd == null)
                {
                    var errorMessage = string.Format(resourceManager.GetString("NotFound"), $"Student by requested id [{studentId}] was");
                    throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
                }

                students.Add(studentToAdd);
            }

            foreach (var student in students)
            {
                group.Students.Remove(student);
            }

            groupRepository.Save();
        }
    }
}
