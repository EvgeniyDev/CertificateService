using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentById(int id);
        public void Add(Student newStudent);
        public void Update(Student student);
        public void Delete(int id);
        public void Save();
    }
}
