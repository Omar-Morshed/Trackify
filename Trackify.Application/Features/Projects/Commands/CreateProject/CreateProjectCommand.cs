using System;
using MediatR;

namespace Trackify.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest<bool>
{
    public string Name { get; set; } = "";
    public string Title { get; set; } = "";
    public string? Description { get; set; } = "";
}
