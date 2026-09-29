using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Comments;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Comments.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        //* Prevent adding to nonexisting Task
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.CommentDTO.TaskId);

        if (task is null) return TaskErrors.NotFound;

        if(request.CommentDTO.Content == "") return CommentErrors.EmptyContent;

        var comment = request.CommentDTO.Adapt<Comment>();
        _unitOfWork.CommentRepository.Add(comment);
        
        await _unitOfWork.SaveAsync();
        return true;

        /* catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return false;
        } */
    }
}
