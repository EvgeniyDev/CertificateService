using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(int id)
        {
            var student = studentsService.GetStudent(id);

            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = studentsService.GetStudents();

            return Ok(students);
        }

        [HttpPost]
        public IActionResult Add(AddStudentViewModel student)
        {
            studentsService.Add(student);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Update(StudentViewModel student)
        {
            studentsService.Update(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            studentsService.Delete(id);

            return NoContent();
        }
    }
}
