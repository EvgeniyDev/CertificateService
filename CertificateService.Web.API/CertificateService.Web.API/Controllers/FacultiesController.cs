using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetFacultyById(int id)
        {
            var faculty = await facultiesService.GetFacultyAsync(id);

            return Ok(faculty);
        }

        [HttpGet("facultyNumbers/{number}")]
        public async Task<IActionResult> GetFacultyByNumber(int number)
        {
            var faculty = await facultiesService.GetFacultyByNumberAsync(number);

            return Ok(faculty);
        }

        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await facultiesService.GetFacultiesAsync();

            return Ok(faculties);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFacultyViewModel faculty)
        {
            await facultiesService.AddAsync(faculty);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("groups/{facultyId}")]
        public async Task<IActionResult> AddGroupsToFaculty(int facultyId, int[] groupIds)
        {
            await facultiesService.AddGroupsToFacultyAsync(facultyId, groupIds);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("groups/{facultyId}")]
        public async Task<IActionResult> RemoveGroupsToFaculty(int facultyId, int[] groupIds)
        {
            await facultiesService.RemoveGroupsFromFacultyAsync(facultyId, groupIds);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFacultyViewModel faculty)
        {
            await facultiesService.UpdateAsync(faculty);

            return Ok(faculty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await facultiesService.DeleteAsync(id);

            return NoContent();
        }
    }
}
