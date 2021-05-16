using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task AddAsync(Student newStudent)
        {
            await appDBContext.Students.AddAsync(newStudent);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var studentToDelete = await GetStudentAsync(s => s.Id == id);

            if (studentToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentToDelete.StudentData);
                appDBContext.StudentTickets.Remove(studentToDelete.StudentTicket);
                appDBContext.Students.Remove(studentToDelete);
                await SaveAsync();
            }
        }

        public async Task<Student> GetStudentAsync(Expression<Func<Student, bool>> predicate)
        {
            return await appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            appDBContext.Update(student);
            await SaveAsync();
        }
    }
}
