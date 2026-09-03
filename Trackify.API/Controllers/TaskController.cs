using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackify.Application.Features.Tasks.Commands.CreateTask;
using Trackify.Application.Features.Tasks.Commands.DeleteTask;
using Trackify.Application.Features.Tasks.Commands.UpdateTask;
using Trackify.Application.Features.Tasks.Queries.GetTaskById;
using Trackify.Application.Features.Tasks.Queries.GetTasks;

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
            var tasks = await _sender.Send(new GetTasksQuery());
            if (tasks.Count() == 0)
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {
            var task = await _sender.Send(new GetTaskByIdQuery(id));
            if (task is null)
                return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateTaskCommand command)
        {
            bool isCreated = await _sender.Send(command);
            if(!isCreated)
                return BadRequest("Didn't Create !");
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTaskAsync(DeleteTaskCommand command)
        {
            bool isDeleted = await _sender.Send(command);
            if(!isDeleted)
                return BadRequest("Didn't Delete");
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(UpdateTaskCommand command)
        {
            bool isUpdated = await _sender.Send(command);
            if(!isUpdated)
                return BadRequest("Didn't Update");
            return Ok();
        }
    }
}
