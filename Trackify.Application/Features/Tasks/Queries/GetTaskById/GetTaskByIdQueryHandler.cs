using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Entities.Task>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<Domain.Entities.Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
