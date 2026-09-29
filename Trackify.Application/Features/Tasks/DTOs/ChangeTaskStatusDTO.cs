using System;

namespace Trackify.Application.Features.Tasks.DTOs;
using TaskStatus = Domain.Enums.TaskStatus;

public class ChangeTaskStatusDTO
{
    public TaskStatus NewStatus { get; set; }
}
