using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Commands.UpdateTask;

namespace Trackify.Application.Features.Tasks.Validators;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Id is required");
        RuleFor(x => x.Task.Name)
            .NotEmpty().WithMessage("The Name is required");
        RuleFor(x => x.Task.Description)
            .NotEmpty().WithMessage("The Description is required");
    }
}
