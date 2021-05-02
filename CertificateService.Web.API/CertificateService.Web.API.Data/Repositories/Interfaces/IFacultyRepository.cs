using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IFacultyRepository
    {
        public IEnumerable<Faculty> GetFaculties();
        public Faculty GetFacultyById(int id);
        public Faculty GetFacultyByName(string name);
        public void Add(Faculty newFaculty);
        public void Update(Faculty faculty);
        public void Delete(int id);
        public void Save();
    }
}
