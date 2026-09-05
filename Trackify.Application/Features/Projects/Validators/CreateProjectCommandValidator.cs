using System;
using FluentValidation;
using Trackify.Application.Features.Projects.Commands.CreateProject;

namespace Trackify.Application.Features.Projects.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Name is Required");
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("The Title is Required");
    }
}
