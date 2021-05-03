using AutoMapper;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services
{
    public class FacultiesService : IFacultiesService
    {
        private readonly IMapper mapper;
        private readonly IFacultyRepository facultyRepository;

        public FacultiesService(IFacultyRepository facultyRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.facultyRepository = facultyRepository;
        }

        public void Add(AddFacultyViewModel newFaculty)
        {
            var facultyToAdd = mapper.Map<Faculty>(newFaculty);

            facultyRepository.Add(facultyToAdd);
        }

        public void Delete(int id)
        {
            facultyRepository.Delete(id);
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return facultyRepository.GetFaculties();
        }

        public Faculty GetFaculty(int id)
        {
            return facultyRepository.GetFacultyById(id);
        }

        public void Update(UpdateFacultyViewModel faculty)
        {
            var facultyToUpdate = mapper.Map<Faculty>(faculty);

            facultyRepository.Update(facultyToUpdate);
        }
    }
}
