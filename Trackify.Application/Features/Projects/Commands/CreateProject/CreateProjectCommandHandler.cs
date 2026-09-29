using System;
using System.Diagnostics;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Projects;

namespace Trackify.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {

        var isNameTaken = await _unitOfWork.ProjectRepository.AnyAsync(p => p.Name == request.Name);

        if (isNameTaken) return ProjectErrors.DuplicateName;

        var project = new Project()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Title = request.Title,
            Description = request.Description,
        };

        _unitOfWork.ProjectRepository.Add(project);
        await _unitOfWork.SaveAsync();
        return project.Id;
        
        /* catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
            return Result<Guid>.Failure(new Error("Project.CreateProjectCommandHandler", "Something wrong while Creating the Project ..."));
        } */
    }
}
