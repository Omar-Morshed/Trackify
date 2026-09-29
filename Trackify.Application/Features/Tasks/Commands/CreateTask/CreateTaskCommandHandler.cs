using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities;
using Trackify.Domain.Entities.Comments;
using Trackify.Domain.Entities.Projects;
using Trackify.Domain.Entities.Tasks;
using Task = Trackify.Domain.Entities.Tasks.Task;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        //* Prevent adding to nonexisting project
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);
        
        if(project is null) return ProjectErrors.NotFound;

        var task = new Task()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description ?? "No Description",
            ProjectId = request.ProjectId,
            Comments = new List<Comment>()
        };
        _unitOfWork.TaskRepository.Add(task);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
