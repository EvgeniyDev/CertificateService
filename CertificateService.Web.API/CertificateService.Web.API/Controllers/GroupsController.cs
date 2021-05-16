using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            this.groupsService = groupsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await groupsService.GetGroupAsync(id);

            return Ok(group);
        }

        [HttpGet("groupNames/{name}")]
        public async Task<IActionResult> GetGroupByName(string name)
        {
            var group = await groupsService.GetGroupAsync(name);

            return Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await groupsService.GetGroupsAsync();

            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGroupViewModel group)
        {
            await groupsService.AddAsync(group);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("students/{groupId}")]
        public async Task<IActionResult> AddGroupsToFaculty(int groupId, int[] studentIds)
        {
            await groupsService.AddStudentsToGroupAsync(groupId, studentIds);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("students/{groupId}")]
        public async Task<IActionResult> RemoveGroupsToFaculty(int groupId, int[] studentIds)
        {
            await groupsService.RemoveStudentsFromGroupAsync(groupId, studentIds);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupViewModel group)
        {
            await groupsService.UpdateAsync(group);

            return Ok(group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await groupsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
