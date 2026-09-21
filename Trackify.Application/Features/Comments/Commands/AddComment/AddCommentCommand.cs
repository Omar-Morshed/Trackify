using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;

namespace Trackify.Application.Features.Comments.Commands.AddComment;

public record AddCommentCommand(CommentDTO CommentDTO) : IRequest<bool>;
