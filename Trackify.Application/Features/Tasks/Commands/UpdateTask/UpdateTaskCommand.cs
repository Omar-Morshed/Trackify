using System;
using MediatR;
using Trackify.Application.Features.Tasks.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(Guid Id, UpdateTaskRequest Task) : IRequest<Result>
{}
