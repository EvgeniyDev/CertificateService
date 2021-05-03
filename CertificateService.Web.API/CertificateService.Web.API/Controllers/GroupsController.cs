﻿using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(int id)
        {
            var group = groupsService.GetGroup(id);

            return Ok(group);
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = groupsService.GetGroups();

            return Ok(groups);
        }

        [HttpPost]
        public IActionResult Add(AddGroupViewModel group)
        {
            groupsService.Add(group);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Update(UpdateGroupViewModel group)
        {
            groupsService.Update(group);

            return Ok(group);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            groupsService.Delete(id);

            return NoContent();
        }
    }
}
