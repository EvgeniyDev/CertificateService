using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDBContext appDBContext;

        public FacultyRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(Faculty newFaculty)
        {
            appDBContext.Faculties.Add(newFaculty);
            Save();
        }

        public void Delete(int id)
        {
            var facultyToDelete = GetFacultyById(id);

            if (facultyToDelete != null)
            {
                appDBContext.Faculties.Remove(facultyToDelete);
                Save();
            }
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return appDBContext.Faculties
                .Include(f => f.Groups).ThenInclude(g => g.Students).ThenInclude(s => s.StudentData)
                .Include(f => f.Groups).ThenInclude(g => g.Students).ThenInclude(s => s.StudentTicket)
                .AsNoTracking();
        }

        public Faculty GetFacultyById(int id)
        {
            return appDBContext.Faculties
                .Include(f => f.Groups)
                .FirstOrDefault(x => x.Id == id);
        }

        public Faculty GetFacultyByName(string name)
        {
            return appDBContext.Faculties
                .Include(f => f.Groups)
                .FirstOrDefault(x => x.Name == name);
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            appDBContext.Update(faculty);

            Save();
        }
    }
}
