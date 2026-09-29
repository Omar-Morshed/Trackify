using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand(Guid Id) : IRequest<Result>;
