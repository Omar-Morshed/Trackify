using System;
using FluentValidation;
using Trackify.Application.Features.Comments.Commands.UpdateComment;

namespace Trackify.Application.Features.Comments.Validators;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(c => c.CommentId)
            .NotEmpty().WithMessage("The Comment Id is required");
        RuleFor(c => c.CommentDTO.Content)
            .NotEmpty().WithMessage("The Comment Content is required");
    }
}
