using MediatR;
using Trackify.Application.Features.Projects.DTOs;

namespace Trackify.Application.Features.Projects.Commands.UpdateProject;

public record UpdateProjectCommand(Guid Id, UpdateProjectRequest Project) : IRequest<bool>;

