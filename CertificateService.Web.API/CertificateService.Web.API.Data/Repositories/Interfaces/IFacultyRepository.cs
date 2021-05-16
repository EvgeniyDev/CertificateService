using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetFacultiesAsync();
        Task<Faculty> GetFacultyByPredicateAsync(Expression<Func<Faculty, bool>> predicate);
        Task AddAsync(Faculty newFaculty);
        Task UpdateAsync(Faculty faculty);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
