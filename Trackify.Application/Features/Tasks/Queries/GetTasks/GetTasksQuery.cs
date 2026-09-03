using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQuery : IRequest<IEnumerable<TaskInfoDTO>>
{

}
