using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            var studentToDelete = GetStudent(s => s.Id == id);

            if (studentToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentToDelete.StudentData);
                appDBContext.StudentTickets.Remove(studentToDelete.StudentTicket);
                appDBContext.Students.Remove(studentToDelete);
                Save();
            }
        }

        public Student GetStudent(Expression<Func<Student, bool>> predicate)
        {
            return appDBContext.Students
                .Include(s => s.StudentData)
                .Include(s => s.StudentTicket)
                .FirstOrDefault(predicate);
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
