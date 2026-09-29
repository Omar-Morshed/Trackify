using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Projects.Commands.DeleteProject;

public record DeleteProjectCommand(Guid Id) : IRequest<Result>;
