using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Comments;

namespace Trackify.Application.Features.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var dbComment = await _unitOfWork.CommentRepository.GetByIdAsync(request.CommentId);

        if (dbComment == null) return CommentErrors.NotFound;
        if (request.CommentDTO.Content == "") return CommentErrors.EmptyContent;

        request.CommentDTO.Adapt(dbComment);
        _unitOfWork.CommentRepository.Update(dbComment);
        await _unitOfWork.SaveAsync();
        return true;

        /* catch(Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        } */
    }
}
