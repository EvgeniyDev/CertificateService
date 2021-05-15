using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            var facultyToDelete = GetFacultyByPredicate(f => f.Id == id);

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

        public Faculty GetFacultyByPredicate(Expression<Func<Faculty, bool>> predicate)
        {
            return appDBContext.Faculties
                .Include(f => f.Groups)
                .FirstOrDefault(predicate);
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
