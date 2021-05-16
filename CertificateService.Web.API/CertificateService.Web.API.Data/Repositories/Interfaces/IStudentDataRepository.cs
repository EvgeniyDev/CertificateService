using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentDataRepository
    {
        Task<IEnumerable<StudentData>> GetStudentDatasAsync();
        Task<StudentData> GetStudentDataByPredicateAsync(Expression<Func<StudentData, bool>> predicate);
        Task AddAsync(StudentData newStudentData);
        Task UpdateAsync(StudentData studentData);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
