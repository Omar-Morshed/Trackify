using System;
using MediatR;

namespace Trackify.Application.Features.Comments.Commands.DeleteComment;

public record DeleteCommentCommand(Guid CommentId) : IRequest<bool>;
