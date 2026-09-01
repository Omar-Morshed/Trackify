using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<Domain.Entities.Task>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTasksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<List<Domain.Entities.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
