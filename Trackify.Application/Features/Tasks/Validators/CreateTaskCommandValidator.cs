using System;
using FluentValidation;
using Trackify.Application.Features.Tasks.Commands.CreateTask;

namespace Trackify.Application.Features.Tasks.Validators;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Name is Required");
    }
}
