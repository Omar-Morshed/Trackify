using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<Project>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProjectRepository.GetAllAsync();
    }
}
