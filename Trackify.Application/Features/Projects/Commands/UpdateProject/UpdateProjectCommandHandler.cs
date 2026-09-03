using System;
using Mapster;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);
        if (project == null)
            return false;
        request.Project.Adapt(project);
        _unitOfWork.ProjectRepository.Update(project);
        return await _unitOfWork.SaveAsync() == 1;
    }
}
