using CertificateService.Web.API.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IStudentsService
    {
        Task AddAsync(AddStudentViewModel newStudent);
        Task DeleteAsync(int id);
        Task UpdateAsync(StudentViewModel student);
        Task<IEnumerable<StudentViewModel>> GetStudentsAsync();
        Task<StudentViewModel> GetStudentAsync(int id);
        Task<StudentViewModel> GetStudentAsync(string name, string surname, string patornymic);
        Task<StudentViewModel> GetStudentAsync(string studentTicketNumber);
    }
}
