using System;
using Mapster;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Application.Interface;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities.Tasks;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskInfoDTO?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TaskInfoDTO?>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var taskEntity = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
        if(taskEntity == null) return TaskErrors.NotFound;
        
        var taskInfo = taskEntity.Adapt<TaskInfoDTO>();
        return taskInfo;
    }
}
