namespace Trackify.Application.Features.Projects.DTOs;

public record UpdateProjectRequest(
    string Name,
    string Title,
    string Description
);
