using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    /// <summary>
    /// A controller for students manipulations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Role.Admin)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsController"/> class.
        /// </summary>
        /// <param name="studentsService"><see cref="IStudentsService"/>.</param>
        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        /// <summary>
        /// Gets student by specified id.
        /// </summary>
        /// <param name="id">Student id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await studentsService.GetStudentAsync(id);

            return Ok(student);
        }

        /// <summary>
        /// Gets student by specified full name.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="surname">Student surname.</param>
        /// <param name="patronymic">Student patronymic.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("{name}/{surname}/{patronymic}")]
        public async Task<IActionResult> GetByFullName(string name, string surname, string patronymic)
        {
            var student = await studentsService.GetStudentAsync(name, surname, patronymic);

            return Ok(student);
        }

        /// <summary>
        /// Gets student by specified student's ticket number.
        /// </summary>
        /// <param name="studentTicketNumber">Student's ticket number.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("studentTickets/{studentTicketNumber}")]
        public async Task<IActionResult> GetByStudentTicketNumber(string studentTicketNumber)
        {
            var student = await studentsService.GetStudentAsync(studentTicketNumber);

            return Ok(student);
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentsService.GetStudentsAsync();

            return Ok(students);
        }

        /// <summary>
        /// Adds new student.
        /// </summary>
        /// <param name="student">Student to add.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
            await studentsService.AddAsync(student);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Updates existing student.
        /// </summary>
        /// <param name="student">Student data to update with.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(StudentViewModel student)
        {
            await studentsService.UpdateAsync(student);

            return Ok(student);
        }

        /// <summary>
        /// Deletes existing student.
        /// </summary>
        /// <param name="id">Student id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
