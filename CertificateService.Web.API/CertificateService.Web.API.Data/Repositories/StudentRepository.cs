using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(Student newStudent)
        {
            appDBContext.Students.Add(newStudent);
            Save();
        }

        public void Delete(int id)
        {
            var studentToDelete = GetStudentById(id);

            if (studentToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentToDelete.StudentData);
                appDBContext.StudentTickets.Remove(studentToDelete.StudentTicket);
                appDBContext.Students.Remove(studentToDelete);
                Save();
            }
        }

        public Student GetStudentById(int id)
        {
            return appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .AsNoTracking();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Student student)
        {
            appDBContext.Update(student);
            Save();
        }
    }
}
