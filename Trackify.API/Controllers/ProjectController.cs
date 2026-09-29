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
            var result = await _sender.Send(new GetProjectsQuery());
            if (result.IsSuccess)
                return Ok(result.Data);
            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound,
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProjectByIdAsync(Guid id)
        {
            var result = await _sender.Send(new GetProjectByIdQuery(id));
            if (result.IsSuccess)
                return Ok(result.Data);
            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound,
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync(CreateProjectCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest
            });
        }

        /* [HttpPut]
        public IActionResult MyProperty { get; set; } */

        [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync(UpdateProjectCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest
            });
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteProjectAsync(Guid Id)
        {
            var result = await _sender.Send(new DeleteProjectCommand(Id));
            if (result.IsSuccess)
                return Ok();
            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest
            });
        }
    }
}
