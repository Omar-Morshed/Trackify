using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Commands.DeleteTask;

namespace Trackify.Application.Features.Tasks.Validators;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
    }
}
