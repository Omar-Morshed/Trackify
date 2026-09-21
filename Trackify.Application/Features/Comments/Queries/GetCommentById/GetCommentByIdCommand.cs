using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;

namespace Trackify.Application.Features.Comments.Queries.GetCommentById;

public record GetCommentByIdCommand(Guid CommentId) : IRequest<CommentDTO?>;
