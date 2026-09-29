using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Projects.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, Result<IEnumerable<ProjectInfoDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<ProjectInfoDTO>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetAllAsync();
        var projectInfoDto = project.Adapt<IEnumerable<ProjectInfoDTO>>();
        if(projectInfoDto == null)
            return TaskErrors.NotFound;
        return Result<IEnumerable<ProjectInfoDTO>>.Success(projectInfoDto);
    }
}
