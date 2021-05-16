using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Expression<Func<Student, bool>> predicate);
        Task AddAsync(Student newStudent);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
