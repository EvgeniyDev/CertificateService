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
    /// A controller for faculties manipulations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Role.Admin)]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultiesService facultiesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacultiesController"/> class.
        /// </summary>
        /// <param name="facultiesService"><see cref="IFacultiesService"/>.</param>
        public FacultiesController(IFacultiesService facultiesService)
        {
            this.facultiesService = facultiesService;
        }

        /// <summary>
        /// Gets faculty by specified id.
        /// </summary>
        /// <param name="id">Faculty id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacultyById(int id)
        {
            var faculty = await facultiesService.GetFacultyAsync(id);

            return Ok(faculty);
        }

        /// <summary>
        /// Gets faculty by specified number.
        /// </summary>
        /// <param name="number">Faculty number.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("facultyNumbers/{number}")]
        public async Task<IActionResult> GetFacultyByNumber(int number)
        {
            var faculty = await facultiesService.GetFacultyByNumberAsync(number);

            return Ok(faculty);
        }

        /// <summary>
        /// Gets all faculties.
        /// </summary>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await facultiesService.GetFacultiesAsync();

            return Ok(faculties);
        }

        /// <summary>
        /// Adds new faculty.
        /// </summary>
        /// <param name="faculty">Faculty to add.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddFacultyViewModel faculty)
        {
            await facultiesService.AddAsync(faculty);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Adds groups to faculty.
        /// </summary>
        /// <param name="facultyId">Faculty id.</param>
        /// <param name="groupIds">Group ids'.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPost("groups/{facultyId}")]
        public async Task<IActionResult> AddGroupsToFaculty(int facultyId, int[] groupIds)
        {
            await facultiesService.AddGroupsToFacultyAsync(facultyId, groupIds);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Removes groups from faculty.
        /// </summary>
        /// <param name="facultyId">Faculty id.</param>
        /// <param name="groupIds">Group ids'.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpDelete("groups/{facultyId}")]
        public async Task<IActionResult> RemoveGroupsFromFaculty(int facultyId, int[] groupIds)
        {
            await facultiesService.RemoveGroupsFromFacultyAsync(facultyId, groupIds);

            return NoContent();
        }

        /// <summary>
        /// Updates existing faculty.
        /// </summary>
        /// <param name="faculty">Faculty data to update with.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFacultyViewModel faculty)
        {
            await facultiesService.UpdateAsync(faculty);

            return Ok(faculty);
        }

        /// <summary>
        /// Deletes existing faculty.
        /// </summary>
        /// <param name="id">Faculty id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await facultiesService.DeleteAsync(id);

            return NoContent();
        }
    }
}
