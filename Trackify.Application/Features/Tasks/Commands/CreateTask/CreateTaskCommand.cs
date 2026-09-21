using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Name, string? Description, Guid ProjectId) : IRequest<bool>;
