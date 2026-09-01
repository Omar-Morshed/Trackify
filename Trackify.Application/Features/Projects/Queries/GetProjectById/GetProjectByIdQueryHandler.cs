using System;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);
    }
}
