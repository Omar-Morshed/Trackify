using System;
using FluentValidation;
using Trackify.Application.Features.Projects.Commands.DeleteProject;

namespace Trackify.Application.Features.Projects.Validators;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
    }
}
