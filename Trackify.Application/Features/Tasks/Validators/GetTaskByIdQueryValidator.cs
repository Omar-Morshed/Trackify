using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Queries.GetTaskById;

namespace Trackify.Application.Features.Tasks.Validators;

public class GetTaskByIdQueryValidator : AbstractValidator<GetTaskByIdQuery>
{
    public GetTaskByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
    }
}
