using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(Guid Id) : IRequest<TaskInfoDTO?>
{

}
