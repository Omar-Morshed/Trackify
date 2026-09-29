using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackify.Application.Features.Comments.Commands.AddComment;
using Trackify.Application.Features.Comments.Commands.DeleteComment;
using Trackify.Application.Features.Comments.Commands.UpdateComment;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Features.Comments.Queries.GetCommentById;
using Trackify.Application.Features.Comments.Queries.GetTaskComments;

namespace Trackify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ISender _sender;

        public CommentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetCommentsByTaskId/{TaskId:guid}")]
        public async Task<IActionResult> GetCommentsByTaskIdAsync(Guid TaskId)
        {
            var result = await _sender.Send(new GetTaskCommentsCommand(TaskId));
            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound
            });
        }
        [HttpGet("{CommentId:guid}")]
        public async Task<IActionResult> GetCommentByIdAsync(Guid CommentId)
        {
            var result = await _sender.Send(new GetCommentByIdCommand(CommentId));
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
        public async Task<IActionResult> PostAsync([FromBody] AddCommentDTO comment)
        {
            var result = await _sender.Send(new AddCommentCommand(comment));

            if (result.IsSuccess)
                return Created();

            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest
            });
        }


        [HttpPut("{CommentId:guid}")]
        public async Task<IActionResult> PutAsync(Guid CommentId, [FromBody] UpdateCommentDTO commentDTO)
        {
            var result = await _sender.Send(new UpdateCommentCommand(CommentId, commentDTO));
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status400BadRequest
            });
        }

        [HttpDelete("{CommentId:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid CommentId)
        {
            var result = await _sender.Send(new DeleteCommentCommand(CommentId));
            if (result.IsSuccess)
                return NoContent();

            return NotFound(new ProblemDetails()
            {
                Title = result.Error.Code,
                Detail = result.Error.Description,
                Status = StatusCodes.Status404NotFound
            });
        }
    }
}
