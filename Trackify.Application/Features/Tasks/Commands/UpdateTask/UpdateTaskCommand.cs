using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;

namespace Trackify.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(Guid Id, UpdateTaskRequest Task) : IRequest<bool>
{}
