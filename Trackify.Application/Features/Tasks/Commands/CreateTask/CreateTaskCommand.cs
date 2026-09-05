using System;
using MediatR;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ProjectId { get; set; }
}
