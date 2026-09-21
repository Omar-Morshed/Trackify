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
            var taskComments = await _sender.Send(new GetTaskCommentsCommand(TaskId));
            return Ok(taskComments);
        }
        [HttpGet("{CommentId:guid}")]
        public async Task<IActionResult> GetCommentByIdAsync(Guid CommentId)
        {
            var comment = await _sender.Send(new GetCommentByIdCommand(CommentId));
            if (comment == null) return NotFound("The Comment Not Found !");
            return Ok(comment);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CommentDTO comment)
        {
            var isAdded = await _sender.Send(new AddCommentCommand(comment));

            if (!isAdded) return BadRequest("Failed to Add !");

            return Ok("Added Successfully !");
        }


        [HttpPut("{CommentId:guid}")]
        public async Task<IActionResult> PutAsync(Guid CommentId, [FromBody] CommentDTO commentDTO)
        {
            var isUpdated = await _sender.Send(new UpdateCommentCommand(CommentId, commentDTO));
            if (!isUpdated) return BadRequest("Failed To Update !");
            return Ok("Updated Successfully !");
        }

        [HttpDelete("{CommentId:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid CommentId)
        {
            var isDeleted = await _sender.Send(new DeleteCommentCommand(CommentId));
            if (!isDeleted) return BadRequest("Failed To Delete !");
            return Ok("Deleted Successfully !");
        }
    }
}
