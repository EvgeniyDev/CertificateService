using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDBContext appDBContext;

        public FacultyRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task AddAsync(Faculty newFaculty)
        {
            await appDBContext.Faculties.AddAsync(newFaculty);

            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var facultyToDelete = await GetFacultyByPredicateAsync(f => f.Id == id);

            if (facultyToDelete != null)
            {
                appDBContext.Faculties.Remove(facultyToDelete);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<Faculty>> GetFacultiesAsync()
        {
            return await appDBContext.Faculties
                .Include(f => f.Groups).ThenInclude(g => g.Students).ThenInclude(s => s.StudentData)
                .Include(f => f.Groups).ThenInclude(g => g.Students).ThenInclude(s => s.StudentTicket)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Faculty> GetFacultyByPredicateAsync(Expression<Func<Faculty, bool>> predicate)
        {
            return await appDBContext.Faculties
                .Include(f => f.Groups)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Faculty faculty)
        {
            appDBContext.Update(faculty);

            await SaveAsync();
        }
    }
}
