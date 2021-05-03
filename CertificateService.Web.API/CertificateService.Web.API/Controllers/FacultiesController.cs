using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CertificateService.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultiesService facultiesService;

        public FacultiesController(IFacultiesService facultiesService)
        {
            this.facultiesService = facultiesService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var faculty = facultiesService.GetFaculty(id);

            return Ok(faculty);
        }

        [HttpGet]
        public IActionResult GetFaculties()
        {
            var faculties = facultiesService.GetFaculties();

            return Ok(faculties);
        }

        [HttpPost]
        public IActionResult Add(Faculty faculty)
        {
            facultiesService.Add(faculty);

            return CreatedAtAction(nameof(Faculty), faculty);
        }

        [HttpPut]
        public IActionResult Update(Faculty faculty)
        {
            facultiesService.Update(faculty);

            return Ok(faculty);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            facultiesService.Delete(id);

            return NoContent();
        }
    }
}
