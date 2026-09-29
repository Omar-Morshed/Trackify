using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(Guid Id) : IRequest<Result<TaskInfoDTO?>>
{

}
