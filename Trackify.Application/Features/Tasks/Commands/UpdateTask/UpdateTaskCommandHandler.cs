using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
        if (task == null)
            return TaskErrors.NotFound;
        request.Task.Adapt(task);
        _unitOfWork.TaskRepository.Update(task);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
