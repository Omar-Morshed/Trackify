using System;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Entities;

namespace Trackify.Application.Interface;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<CommentDTO>> GetTaskComments(Guid? TaskId, CancellationToken cancellationToken = default);
}
