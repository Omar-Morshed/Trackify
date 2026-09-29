using MediatR;
using Trackify.Application.Features.Projects.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Projects.Commands.UpdateProject;

public record UpdateProjectCommand(Guid Id, UpdateProjectRequest Project) : IRequest<Result>;

