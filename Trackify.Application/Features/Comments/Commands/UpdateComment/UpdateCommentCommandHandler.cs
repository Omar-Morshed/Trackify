using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dbComment = await _unitOfWork.CommentRepository.GetByIdAsync(request.CommentId);
            if (dbComment == null) return false;

            request.CommentDTO.Adapt(dbComment);
            _unitOfWork.CommentRepository.Update(dbComment);
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        }
    }
}
