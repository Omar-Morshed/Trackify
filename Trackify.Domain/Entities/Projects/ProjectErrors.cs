using System;
using Trackify.Domain.Abstractions;

namespace Trackify.Domain.Entities.Projects;

public static class ProjectErrors
{
    public static readonly Error NotFound = new(
        "Project.NotFound", 
        "The specified project was not found.");

    public static readonly Error DuplicateName = new (
        "Project.DuplicateName", 
        "A project with the same name already exists.");
}
