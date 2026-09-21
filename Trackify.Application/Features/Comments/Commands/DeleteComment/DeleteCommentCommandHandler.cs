using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Comments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.CommentRepository.DeleteAsync(request.CommentId);
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        }
    }
}
