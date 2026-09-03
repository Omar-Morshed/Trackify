using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
        if (task == null)
            return false;
        request.Task.Adapt(task);
        _unitOfWork.TaskRepository.Update(task);
        return await _unitOfWork.SaveAsync() == 1;
    }
}
