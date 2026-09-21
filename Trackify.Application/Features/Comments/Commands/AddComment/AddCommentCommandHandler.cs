using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Comments.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = request.CommentDTO.Adapt<Comment>();
            _unitOfWork.CommentRepository.Add(comment);
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        }
    }
}
