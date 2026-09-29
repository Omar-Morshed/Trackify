using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Comments;

namespace Trackify.Application.Features.Comments.Queries.GetTaskComments;

public class GetTaskCommentsCommandHandler : IRequestHandler<GetTaskCommentsCommand, Result<IEnumerable<AddCommentDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskCommentsCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<AddCommentDTO>>> Handle(GetTaskCommentsCommand request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.GetTaskComments(request.TaskId, cancellationToken);
        
        if(comments is null) return CommentErrors.NotFound;
        
        return Result<IEnumerable<AddCommentDTO>>.Success(comments);
    }
}
