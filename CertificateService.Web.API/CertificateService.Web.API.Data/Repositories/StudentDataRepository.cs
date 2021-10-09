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
    /// <inheritdoc cref="IStudentDataRepository"/>
    public class StudentDataRepository : IStudentDataRepository
    {
        private readonly AppDBContext appDBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDataRepository"/> class.
        /// </summary>
        /// <param name="appDBContext"><see cref="AppDBContext"/>.</param>
        public StudentDataRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <inheritdoc/>
        public async Task AddAsync(StudentData newStudentData)
        {
            await appDBContext.StudentDatas.AddAsync(newStudentData);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var studentDataToDelete = await GetStudentDataByPredicateAsync(sd => sd.Id == id);

            if (studentDataToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentDataToDelete);
                await SaveAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<StudentData> GetStudentDataByPredicateAsync(Expression<Func<StudentData, bool>> predicate)
        {
            return await appDBContext.StudentDatas.FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StudentData>> GetStudentsDataAsync()
        {
            return await appDBContext.StudentDatas.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(StudentData studentData)
        {
            appDBContext.Update(studentData);
            await SaveAsync();
        }
    }
}
