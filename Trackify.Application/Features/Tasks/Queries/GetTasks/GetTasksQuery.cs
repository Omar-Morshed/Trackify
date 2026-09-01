using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQuery : IRequest<List<Domain.Entities.Task>>
{

}
