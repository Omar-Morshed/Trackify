using System;
using FluentValidation;
using Trackify.Application.Features.Projects.Queries.GetProjectById;

namespace Trackify.Application.Features.Projects.Validators;

public class GetProjectByIdQueryValidator : AbstractValidator<GetProjectByIdQuery>
{
    public GetProjectByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
    }
}
