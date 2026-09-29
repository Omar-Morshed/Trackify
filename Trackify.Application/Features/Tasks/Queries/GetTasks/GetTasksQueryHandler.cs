using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Result<IEnumerable<TaskInfoDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTasksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<TaskInfoDTO>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasksEntities = await _unitOfWork.TaskRepository.GetAllAsync();

        var tasksInfo = tasksEntities.Adapt<IEnumerable<TaskInfoDTO>>();

        if (tasksInfo is null || !tasksInfo.Any()) return TaskErrors.NotFound;

        return Result<IEnumerable<TaskInfoDTO>>.Success(tasksInfo);
    }
}
