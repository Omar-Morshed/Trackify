using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        // await _unitOfWork.TaskRepository.DeleteAsync(request.Id);
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
        if (task is null) return TaskErrors.NotFound;
        
        _unitOfWork.TaskRepository.Delete(task);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
