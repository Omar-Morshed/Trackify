using System;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Entities.Comments;

namespace Trackify.Application.Interface;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<AddCommentDTO>> GetTaskComments(Guid? TaskId, CancellationToken cancellationToken = default);
}
