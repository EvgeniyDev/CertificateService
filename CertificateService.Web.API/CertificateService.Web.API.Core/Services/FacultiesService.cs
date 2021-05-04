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
    public class FacultiesService : IFacultiesService
    {
        private readonly ResourceManager resourceManager;

        private readonly IMapper mapper;
        private readonly IFacultyRepository facultyRepository;

        public FacultiesService(IFacultyRepository facultyRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.facultyRepository = facultyRepository;

            resourceManager = new ResourceManager(typeof(ErrorMessages).FullName, typeof(ErrorMessages).Assembly);
        }

        public void Add(AddFacultyViewModel newFaculty)
        {
            var facultyToAdd = mapper.Map<Faculty>(newFaculty);

            facultyRepository.Add(facultyToAdd);
        }

        public void Delete(int id)
        {
            GetFaculty(id);

            facultyRepository.Delete(id);
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            var faculties = facultyRepository.GetFaculties();

            if (!faculties.Any())
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), "Faculties were");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return faculties;
        }

        public Faculty GetFaculty(int id)
        {
            var faculty = facultyRepository.GetFacultyById(id);

            if (faculty == null)
            {
                var errorMessage = string.Format(resourceManager.GetString("NotFound"), "Faculty by requested id");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return faculty;
        }

        public void Update(UpdateFacultyViewModel faculty)
        {
            GetFaculty(faculty.Id);

            var facultyToUpdate = mapper.Map<Faculty>(faculty);
            facultyRepository.Update(facultyToUpdate);
        }
    }
}
