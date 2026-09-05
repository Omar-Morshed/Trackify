using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackify.Application.Features.Projects.Commands.CreateProject;
using Trackify.Application.Features.Projects.Commands.DeleteProject;
using Trackify.Application.Features.Projects.Commands.UpdateProject;
using Trackify.Application.Features.Projects.Queries.GetProjectById;
using Trackify.Application.Features.Projects.Queries.GetProjects;

namespace Trackify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ISender _sender;

        public ProjectController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var project = await _sender.Send(new GetProjectsQuery());
            return Ok(project);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProjectByIdAsync(Guid id)
        {
            var project = await _sender.Send(new GetProjectByIdQuery(id));
            if(project is null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync(CreateProjectCommand command)
        {
            var isCreated = await _sender.Send(command);
            if (isCreated)
                return Ok();
            return BadRequest("The Project didn't create !");
        }

        /* [HttpPut]
        public IActionResult MyProperty { get; set; } */
        
        [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync(UpdateProjectCommand command)
        {
            var isUpdated = await _sender.Send(command);
            if(!isUpdated)
                return BadRequest("Didn't Update");
            return Ok();
        }
        
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteProjectAsync(Guid Id)
        {
            var isDeleted = await _sender.Send(new DeleteProjectCommand(Id));
            if(!isDeleted)
                return BadRequest("Didn't Delete");
            return Ok();
        }
    }
}
