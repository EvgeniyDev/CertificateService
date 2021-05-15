using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(Expression<Func<Student, bool>> predicate);
        public void Add(Student newStudent);
        public void Update(Student student);
        public void Delete(int id);
        public void Save();
    }
}
