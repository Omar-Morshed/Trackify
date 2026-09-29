using System;
using MediatR;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Comments.Commands.DeleteComment;

public record DeleteCommentCommand(Guid CommentId) : IRequest<Result>;
