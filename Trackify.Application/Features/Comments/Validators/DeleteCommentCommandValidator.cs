using System;
using FluentValidation;
using Trackify.Application.Features.Comments.Commands.DeleteComment;

namespace Trackify.Application.Features.Comments.Validators;

public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentCommandValidator()
    {
        RuleFor(c => c.CommentId)
            .NotEmpty().WithMessage("The Comment Id is required");
    }
}
