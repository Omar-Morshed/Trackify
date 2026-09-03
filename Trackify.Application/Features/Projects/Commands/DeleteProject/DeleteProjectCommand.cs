using System;
using MediatR;

namespace Trackify.Application.Features.Projects.Commands.DeleteProject;

public record DeleteProjectCommand(Guid Id) : IRequest<bool>;
