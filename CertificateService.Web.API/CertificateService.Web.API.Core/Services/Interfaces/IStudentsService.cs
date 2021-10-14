using CertificateService.Web.API.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for manipulating student data.
    /// </summary>
    public interface IStudentsService
    {
        /// <summary>
        /// Adds new student.
        /// </summary>
        /// <param name="newStudent">Student to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(AddStudentViewModel newStudent);

        /// <summary>
        /// Deletes existing student.
        /// </summary>
        /// <param name="id">Student id to be removed.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates existing student.
        /// </summary>
        /// <param name="student">Student data to update with.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(StudentViewModel student);

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{StudentViewModel}"/> representing asynchronus operation.</returns>
        Task<IEnumerable<StudentViewModel>> GetStudentsAsync();

        /// <summary>
        /// Gets student by specified id.
        /// </summary>
        /// <param name="id">Student id.</param>
        /// <returns>A <see cref="Task{StudentViewModel}"/> representing asynchronus operation.</returns>
        Task<StudentViewModel> GetStudentAsync(int id);

        /// <summary>
        /// Gets student by specified name, surname and patronymic.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="surname">Student surname.</param>
        /// <param name="patornymic">Student patronymic.</param>
        /// <returns>A <see cref="Task{StudentViewModel}"/> representing asynchronus operation.</returns>
        Task<StudentViewModel> GetStudentAsync(string name, string surname, string patornymic);

        /// <summary>
        /// Gets student by specified student's ticket number.
        /// </summary>
        /// <param name="studentTicketNumber">Student's ticket number.</param>
        /// <returns>A <see cref="Task{StudentViewModel}"/> representing asynchronus operation.</returns>
        Task<StudentViewModel> GetStudentAsync(string studentTicketNumber);
    }
}
