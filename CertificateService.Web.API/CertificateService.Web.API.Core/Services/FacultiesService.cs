using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services
{
    public class FacultiesService : IFacultiesService
    {
        private readonly IFacultyRepository facultyRepository;

        public FacultiesService(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

        public void Add(Faculty newFaculty)
        {
            facultyRepository.Add(newFaculty);
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

        public void Update(Faculty faculty)
        {
            facultyRepository.Update(faculty);
        }
    }
}
