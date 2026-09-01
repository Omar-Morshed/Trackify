using System;
using MediatR;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
{
    public Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
