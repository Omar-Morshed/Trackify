using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Tasks.Commands.ChangeTaskStatus;

public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeTaskStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.TaskId);
        
        if(task is null) return TaskErrors.NotFound;
        
        var succeeded = task.ChangeStatus(request.NewStatus);
        
        if(!succeeded)
            return TaskErrors.InvalidStatusTransition;
        
        await _unitOfWork.SaveAsync();
        
        return succeeded;
    }
}
