using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand(Guid Id) : IRequest<bool>
{}
