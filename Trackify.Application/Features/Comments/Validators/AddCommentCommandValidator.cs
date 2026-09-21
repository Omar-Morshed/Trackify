using System;
using FluentValidation;
using Trackify.Application.Features.Comments.Commands.AddComment;

namespace Trackify.Application.Features.Comments.Validators;

public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
{
    public AddCommentCommandValidator()
    {
        RuleFor(c => c.CommentDTO.Content)
            .NotEmpty().WithMessage("The Comment Content is required");
        RuleFor(c => c.CommentDTO.TaskId)
            .NotEmpty().WithMessage("The Task Id is required (no comment without a task lol)");
    }
}
