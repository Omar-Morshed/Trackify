using System;
using FluentValidation;
using Trackify.Application.Features.Projects.Commands.UpdateProject;

namespace Trackify.Application.Features.Projects.Validators;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
        RuleFor(x => x.Project.Name)
            .NotEmpty().WithMessage("The Name is required");
        RuleFor(x => x.Project.Description)
            .NotEmpty().WithMessage("The Description is required");
    }
}
