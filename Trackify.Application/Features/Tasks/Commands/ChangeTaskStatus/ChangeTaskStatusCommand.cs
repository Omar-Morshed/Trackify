using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Commands.ChangeTaskStatus;

using TaskStatus = Domain.Enums.TaskStatus;
public record ChangeTaskStatusCommand(Guid TaskId, TaskStatus NewStatus) : IRequest<Result>;
