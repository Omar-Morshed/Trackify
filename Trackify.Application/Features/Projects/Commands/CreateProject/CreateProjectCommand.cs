using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest<Result<Guid>>
{
    public string Name { get; set; } = "";
    public string Title { get; set; } = "";
    public string? Description { get; set; } = "";
}
