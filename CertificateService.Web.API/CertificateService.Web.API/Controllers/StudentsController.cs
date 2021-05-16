using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await studentsService.GetStudentAsync(id);

            return Ok(student);
        }

        [HttpGet("{name}/{surname}/{patronymic}")]
        public async Task<IActionResult> GetByFullName(string name, string surname, string patronymic)
        {
            var student = await studentsService.GetStudentAsync(name, surname, patronymic);

            return Ok(student);
        }

        [HttpGet("studentTickets/{studentTicketNumber}")]
        public async Task<IActionResult> GetByStudentTicketNumber(string studentTicketNumber)
        {
            var student = await studentsService.GetStudentAsync(studentTicketNumber);

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentsService.GetStudentsAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
            await studentsService.AddAsync(student);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentViewModel student)
        {
            await studentsService.UpdateAsync(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
