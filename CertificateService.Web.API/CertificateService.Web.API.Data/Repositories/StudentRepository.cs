using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
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
            newStudent.Id = default;

            appDBContext.Students.Add(newStudent);
            Save();
        }

        public void Delete(int id)
        {
            var studentToDelete = GetStudentById(id);

            if (studentToDelete != null)
            {
                appDBContext.Students.Remove(studentToDelete);
                Save();
            }
        }

        public Student GetStudentById(int id)
        {
            return appDBContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return appDBContext.Students.AsEnumerable();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Student student)
        {
            var studentToUpdate = GetStudentById(student.Id);

            if (studentToUpdate is null)
            {
                Add(student);
            }
            else
            {
                studentToUpdate.GroupId = student.GroupId;
                studentToUpdate.StudentDataId = student.StudentDataId;
                studentToUpdate.StudentTicketId = student.StudentTicketId;

                appDBContext.Update(studentToUpdate);
            }

            Save();
        }
    }
}
