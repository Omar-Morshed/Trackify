using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Commands.ChangeTaskStatus;

namespace Trackify.Application.Features.Tasks.Validators;

public class ChangeTaskStatusCommandValidator : AbstractValidator<ChangeTaskStatusCommand>
{
    public ChangeTaskStatusCommandValidator()
    {
        RuleFor(t => t.TaskId)
            .NotEmpty()
            .WithMessage("The Task Id is required");

        RuleFor(t => t.NewStatus)
            .IsInEnum() //* Used for Enums (instead of .NotEmpty() because it checks the element with its default value)
            .WithMessage("The Task Status is required");
    }
}
