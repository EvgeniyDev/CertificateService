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
    /// <inheritdoc cref="IStudentRepository"/>
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext appDBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="appDBContext"><see cref="AppDBContext"/>.</param>
        public StudentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <inheritdoc/>
        public async Task AddAsync(Student newStudent)
        {
            await appDBContext.Students.AddAsync(newStudent);
            await SaveAsync();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<Student> GetStudentAsync(Expression<Func<Student, bool>> predicate)
        {
            return await appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Student student)
        {
            appDBContext.Update(student);
            await SaveAsync();
        }
    }
}
