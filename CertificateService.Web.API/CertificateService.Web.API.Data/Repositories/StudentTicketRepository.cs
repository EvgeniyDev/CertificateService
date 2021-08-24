using CertificateService.Web.API.Data.Context;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories
{
    public class StudentTicketRepository : IStudentTicketRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentTicketRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task AddAsync(StudentTicket newStudentTicket)
        {
            await appDBContext.StudentTickets.AddAsync(newStudentTicket);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var studentTicketToDelete = await GetStudentTicketByPredicateAsync(st => st.Id == id);

            if (studentTicketToDelete != null)
            {
                appDBContext.StudentTickets.Remove(studentTicketToDelete);
                await SaveAsync();
            }
        }

        public async Task<StudentTicket> GetStudentTicketByPredicateAsync(Expression<Func<StudentTicket, bool>> predicate)
        {
            return await appDBContext.StudentTickets.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<StudentTicket>> GetStudentTicketsAsync()
        {
            return await appDBContext.StudentTickets.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentTicket studentTicket)
        {
            appDBContext.Update(studentTicket);

            await SaveAsync();
        }
    }
}
