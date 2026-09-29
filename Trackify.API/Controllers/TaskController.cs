using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackify.Application.Features.Tasks.Commands.ChangeTaskStatus;
using Trackify.Application.Features.Tasks.Commands.CreateTask;
using Trackify.Application.Features.Tasks.Commands.DeleteTask;
using Trackify.Application.Features.Tasks.Commands.UpdateTask;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Application.Features.Tasks.Queries.GetTaskById;
using Trackify.Application.Features.Tasks.Queries.GetTasks;
using TaskStatus = Trackify.Domain.Enums.TaskStatus; //! NOT BEST PRACTICE !

namespace Trackify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ISender _sender;

        public TaskController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var result = await _sender.Send(new GetTasksQuery());
            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {
            var result = await _sender.Send(new GetTaskByIdQuery(id));
            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateTaskCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest,
            });
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(UpdateTaskCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest,
            });
        }

        [HttpPut("{TaskId:guid}/status")]
        public async Task<IActionResult> ChangeTaskStatusAsync(Guid TaskId, [FromBody] ChangeTaskStatusDTO Status)
        {
            var result = await _sender.Send(new ChangeTaskStatusCommand(TaskId, Status.NewStatus));

            if (result.IsSuccess)
                return Ok();

            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest,
            });

        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteTaskAsync(Guid Id)
        {
            var result = await _sender.Send(new DeleteTaskCommand(Id));
            if (result.IsSuccess)
                return Ok();

            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound,
            });
        }
    }
}
