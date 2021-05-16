using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentTicketRepository
    {
        Task<IEnumerable<StudentTicket>> GetStudentTicketsAsync();
        Task<StudentTicket> GetStudentTicketByPredicateAsync(Expression<Func<StudentTicket, bool>> predicate);
        Task AddAsync(StudentTicket newStudentTicket);
        Task UpdateAsync(StudentTicket studentTicket);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
