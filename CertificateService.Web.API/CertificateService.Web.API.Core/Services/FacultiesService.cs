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
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services
{
    public class FacultiesService : IFacultiesService
    {
        private readonly IMapper mapper;
        private readonly IFacultyRepository facultyRepository;
        private readonly IGroupsService groupsService;

        public FacultiesService(
            IFacultyRepository facultyRepository,
            IGroupsService groupsService,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.facultyRepository = facultyRepository;
            this.groupsService = groupsService;
        }

        public async Task AddAsync(AddFacultyViewModel newFaculty)
        {
            var facultyToAdd = mapper.Map<Faculty>(newFaculty);

            await facultyRepository.AddAsync(facultyToAdd);
        }

        public async Task DeleteAsync(int id)
        {
            await GetFacultyAsync(id);

            await facultyRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Faculty>> GetFacultiesAsync()
        {
            var faculties = await facultyRepository.GetFacultiesAsync();

            if (!faculties.Any())
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, "Faculties were");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return faculties;
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            var faculty = await facultyRepository.GetFacultyByPredicateAsync(f => f.Id == id);

            if (faculty == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Faculty)} by requested id '{id}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return faculty;
        }

        public async Task<Faculty> GetFacultyByNumberAsync(int number)
        {
            var faculty = await facultyRepository .GetFacultyByPredicateAsync(f => f.Number == number);

            if (faculty == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Faculty)} by requested number '{number}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return faculty;
        }

        public async Task UpdateAsync(UpdateFacultyViewModel faculty)
        {
            await GetFacultyAsync(faculty.Id);

            var facultyToUpdate = mapper.Map<Faculty>(faculty);
            await facultyRepository.UpdateAsync(facultyToUpdate);
        }

        public async Task AddGroupsToFacultyAsync(int facultyId, int[] groupIds)
        {
            var faculty = await GetFacultyAsync(facultyId);
            var groups = new List<Group>();

            foreach (var groupId in groupIds)
            {
                groups.Add(await groupsService.GetGroupAsync(groupId));
            }

            foreach (var group in groups)
            {
                if (!faculty.Groups.Any(x => x.Id == group.Id))
                {
                    faculty.Groups.Add(group);
                }
            }

            await facultyRepository.SaveAsync();
        }

        public async Task RemoveGroupsFromFacultyAsync(int facultyId, int[] groupIds)
        {
            var faculty = await GetFacultyAsync(facultyId);
            var groups = new List<Group>();

            foreach (var groupId in groupIds)
            {
                groups.Add(await groupsService.GetGroupAsync(groupId));
            }

            foreach (var group in groups)
            {
                faculty.Groups.Remove(group);
            }

            await facultyRepository.SaveAsync();
        }
    }
}
