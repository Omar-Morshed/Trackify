using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;

namespace Trackify.Application.Features.Comments.Commands.UpdateComment;

public record UpdateCommentCommand(Guid CommentId, CommentDTO CommentDTO) : IRequest<bool>;
