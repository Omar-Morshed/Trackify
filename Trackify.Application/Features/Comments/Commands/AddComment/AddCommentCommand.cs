using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Comments.Commands.AddComment;

public record AddCommentCommand(AddCommentDTO CommentDTO) : IRequest<Result>;
