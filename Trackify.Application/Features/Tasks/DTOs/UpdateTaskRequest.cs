using System;

namespace Trackify.Application.Features.Tasks.DTOs;

public record UpdateTaskRequest(
    string Name,
    string Description
);