using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskInfoDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTasksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<TaskInfoDTO>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasksEntities = await _unitOfWork.TaskRepository.GetAllAsync();
        var tasksInfo = tasksEntities.Adapt<IEnumerable<TaskInfoDTO>>();
        return tasksInfo;
    }
}
