using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Projects.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectInfoDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProjectInfoDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetAllAsync();
        var projectInfoDto = project.Adapt<IEnumerable<ProjectInfoDTO>>();
        return projectInfoDto;
    }
}
