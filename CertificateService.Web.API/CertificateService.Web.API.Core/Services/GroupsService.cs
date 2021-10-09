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
using System.Threading.Tasks;

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

        public async Task AddAsync(AddGroupViewModel newGroup)
        {
            var groupToAdd = mapper.Map<Group>(newGroup);
            await groupRepository.AddAsync(groupToAdd);
        }

        public async Task DeleteAsync(int id)
        {
            await GetGroupAsync(id);

            await groupRepository.DeleteAsync(id);
        }

        public async Task<Group> GetGroupAsync(int id)
        {
            var group = await groupRepository.GetGroupByPredicateAsync(g => g.Id == id);

            if (group == null)
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), $"{nameof(Group)} by requested id [{id}] was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return group;
        }

        public async Task<Group> GetGroupAsync(string groupName)
        {
            var group = await groupRepository.GetGroupByPredicateAsync(g => g.Name == groupName);

            if (group == null)
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), $"Group by requested name [{groupName}] was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return group;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var groups = await groupRepository.GetGroupsAsync();

            if (!groups.Any())
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), "Groups were");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return groups;
        }

        public async Task UpdateAsync(UpdateGroupViewModel group)
        {
            await GetGroupAsync(group.Id);

            var groupToUpdate = mapper.Map<Group>(group);
            await groupRepository.UpdateAsync(groupToUpdate);
        }

        public async Task AddStudentsToGroupAsync(int groupId, int[] studentIds)
        {
            var group = await GetGroupAsync(groupId);
            var students = new List<Student>();

            foreach (var studentId in studentIds)
            {
                var studentToAdd = await studentsRepository.GetStudentAsync(s => s.Id == studentId);

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

            await groupRepository.SaveAsync();
        }

        public async Task RemoveStudentsFromGroupAsync(int groupId, int[] studentIds)
        {
            var group = await GetGroupAsync(groupId);
            var students = new List<Student>();

            foreach (var studentId in studentIds)
            {
                var studentToAdd = await studentsRepository.GetStudentAsync(s => s.Id == studentId);

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

            await groupRepository.SaveAsync();
        }

        public async Task<Group> GetStudentGroupName(int studentId)
        {
            var groups = await GetGroupsAsync();
            var groupWithStudent = groups.FirstOrDefault(g => g.Students.Any(s => s.Id == studentId));

            if (groupWithStudent == null)
            {
                var errorMessage = string.Format(resourceManager.GetString("NotAddedToAnyGroup"), $"Student with id [{studentId}] is");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return groupWithStudent;
        }
    }
}
