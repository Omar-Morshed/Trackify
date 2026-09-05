using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Queries.GetTasks;

namespace Trackify.Application.Features.Tasks.Validators;

public class GetTasksQueryValidator : AbstractValidator<GetTasksQuery>
{
    public GetTasksQueryValidator()
    {}
}
