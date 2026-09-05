using System;
using FluentValidation;
using Trackify.Application.Features.Projects.Queries.GetProjects;

namespace Trackify.Application.Features.Projects.Validators;

public class GetProjectsQueryValidator : AbstractValidator<GetProjectsQuery>
{
    public GetProjectsQueryValidator()
    {}
}
