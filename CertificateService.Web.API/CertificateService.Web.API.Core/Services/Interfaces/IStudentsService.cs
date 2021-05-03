using CertificateService.Web.API.Core.ViewModels;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IStudentsService
    {
        void Add(AddStudentViewModel newStudent);
        void Delete(int id);
        void Update(StudentViewModel student);
        IEnumerable<StudentViewModel> GetStudents();
        StudentViewModel GetStudent(int id);
    }
}
