using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;
using Task = Trackify.Domain.Entities.Task;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Task()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ProjectId = request.ProjectId,
            Comments = new List<Comment>()
        };
        _unitOfWork.TaskRepository.Add(task);
        return await _unitOfWork.SaveAsync() == 1;
    }
}
