using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<Domain.Entities.Task>>
{
    public Task<List<Domain.Entities.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
