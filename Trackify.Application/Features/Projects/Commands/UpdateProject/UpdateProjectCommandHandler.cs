using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Projects;

namespace Trackify.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);
        if (project == null)
            return ProjectErrors.NotFound;

        request.Project.Adapt(project);

        _unitOfWork.ProjectRepository.Update(project);

        await _unitOfWork.SaveAsync();

        return Result.Success();
    }
}
