using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Comments.Commands.UpdateComment;

public record UpdateCommentCommand(Guid CommentId, UpdateCommentDTO CommentDTO) : IRequest<Result>;
