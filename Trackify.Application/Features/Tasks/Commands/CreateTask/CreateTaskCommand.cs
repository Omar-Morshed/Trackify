using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Name, string? Description, Guid ProjectId) : IRequest<Result>;
