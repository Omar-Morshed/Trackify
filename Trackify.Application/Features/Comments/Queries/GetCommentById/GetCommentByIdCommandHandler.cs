using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Comments.Queries.GetCommentById;

public class GetCommentByIdCommandHandler : IRequestHandler<GetCommentByIdCommand, CommentDTO?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCommentByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CommentDTO?> Handle(GetCommentByIdCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(request.CommentId);
        var commentDTO = comment.Adapt<CommentDTO>();
        return commentDTO;
    }
}
