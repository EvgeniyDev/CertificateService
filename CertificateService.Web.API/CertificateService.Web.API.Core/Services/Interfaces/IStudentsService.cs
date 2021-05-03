using CertificateService.Web.API.Core.ViewModel;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IStudentsService
    {
        void Add(StudentViewModel newStudent);
        void Delete(int id);
        void Update(StudentViewModel student);
        IEnumerable<StudentViewModel> GetStudents();
        StudentViewModel GetStudent(int id);
    }
}
