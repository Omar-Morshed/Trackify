using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Comments.Queries.GetTaskComments;

public class GetTaskCommentsCommandHandler : IRequestHandler<GetTaskCommentsCommand, IEnumerable<CommentDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskCommentsCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CommentDTO>> Handle(GetTaskCommentsCommand request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.GetTaskComments(request.TaskId, cancellationToken);
        return comments;
    }
}
