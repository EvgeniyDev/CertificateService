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
    /// A controller for groups manipulations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Role.Admin)]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService groupsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsController"/> class.
        /// </summary>
        /// <param name="groupsService"><see cref="IGroupsService"/>.</param>
        public GroupsController(IGroupsService groupsService)
        {
            this.groupsService = groupsService;
        }

        /// <summary>
        /// Gets group by specified id.
        /// </summary>
        /// <param name="id">Group id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await groupsService.GetGroupAsync(id);

            return Ok(group);
        }

        /// <summary>
        /// Gets group by specified name.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("groupNames/{name}")]
        public async Task<IActionResult> GetGroupByName(string name)
        {
            var group = await groupsService.GetGroupAsync(name);

            return Ok(group);
        }

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await groupsService.GetGroupsAsync();

            return Ok(groups);
        }

        /// <summary>
        /// Adds new group.
        /// </summary>
        /// <param name="group">Group to add.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddGroupViewModel group)
        {
            await groupsService.AddAsync(group);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Adds students to group.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="studentIds">Student ids'.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPost("students/{groupId}")]
        public async Task<IActionResult> AddStudentsToGroup(int groupId, int[] studentIds)
        {
            await groupsService.AddStudentsToGroupAsync(groupId, studentIds);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Removes students from group.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="studentIds">Student ids'.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpDelete("students/{groupId}")]
        public async Task<IActionResult> RemoveStudentsFromGroup(int groupId, int[] studentIds)
        {
            await groupsService.RemoveStudentsFromGroupAsync(groupId, studentIds);

            return NoContent();
        }

        /// <summary>
        /// Updates existing group.
        /// </summary>
        /// <param name="group">Group data to update with.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupViewModel group)
        {
            await groupsService.UpdateAsync(group);

            return Ok(group);
        }

        /// <summary>
        /// Deletes existing group.
        /// </summary>
        /// <param name="id">Group id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await groupsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
