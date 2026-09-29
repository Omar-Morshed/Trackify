using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQuery : IRequest<Result<IEnumerable<TaskInfoDTO>>>
{

}
