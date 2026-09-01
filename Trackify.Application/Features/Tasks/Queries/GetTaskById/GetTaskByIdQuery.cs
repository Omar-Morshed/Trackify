using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQuery : IRequest<Domain.Entities.Task>
{

}
