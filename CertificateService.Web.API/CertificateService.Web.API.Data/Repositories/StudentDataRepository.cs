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
    public class StudentDataRepository : IStudentDataRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentDataRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task AddAsync(StudentData newStudentData)
        {
            await appDBContext.StudentDatas.AddAsync(newStudentData);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var studentDataToDelete = await GetStudentDataByPredicateAsync(sd => sd.Id == id);

            if (studentDataToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentDataToDelete);
                await SaveAsync();
            }
        }

        public async Task<StudentData> GetStudentDataByPredicateAsync(Expression<Func<StudentData, bool>> predicate)
        {
            return await appDBContext.StudentDatas.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<StudentData>> GetStudentDatasAsync()
        {
            return await appDBContext.StudentDatas.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentData studentData)
        {
            appDBContext.Update(studentData);
            await SaveAsync();
        }
    }
}
