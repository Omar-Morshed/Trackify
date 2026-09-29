using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Comments;

namespace Trackify.Application.Features.Comments.Queries.GetCommentById;

public class GetCommentByIdCommandHandler : IRequestHandler<GetCommentByIdCommand, Result<AddCommentDTO>?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCommentByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<AddCommentDTO>?> Handle(GetCommentByIdCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(request.CommentId);
        if(comment is null) return CommentErrors.NotFound;

        var commentDTO = comment.Adapt<AddCommentDTO>();
        return commentDTO;
    }
}
