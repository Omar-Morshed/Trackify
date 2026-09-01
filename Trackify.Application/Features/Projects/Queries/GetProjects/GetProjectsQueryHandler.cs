using System;
using MediatR;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<Project>>
{
    public Task<List<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
