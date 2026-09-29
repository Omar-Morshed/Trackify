using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Comments;

namespace Trackify.Application.Features.Comments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {

        // await _unitOfWork.CommentRepository.DeleteAsync(request.CommentId);
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(request.CommentId);

        if (comment is null) return CommentErrors.NotFound;

        _unitOfWork.CommentRepository.Delete(comment);

        await _unitOfWork.SaveAsync();

        return true;
        
        /* catch (Exception ex)
        {
            System.Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        } */
    }
}
