using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskInfoDTO?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskInfoDTO?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var tasksEntity = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
        var taskInfo = tasksEntity.Adapt<TaskInfoDTO>();
        return taskInfo;
    }
}
