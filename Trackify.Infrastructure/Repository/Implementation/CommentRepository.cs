using System;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Infrastructure.Repository.Implementation;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<CommentDTO>> GetTaskComments(Guid? TaskId, CancellationToken cancellationToken = default)
    {
        var comments = await dbSet.Include(comment => comment.Task)
                                    .Where(comment => comment.TaskId == TaskId)
                                    .ToListAsync(cancellationToken);
        var commentsDto = comments.Adapt<List<CommentDTO>>();
        return commentsDto;
    }
}
