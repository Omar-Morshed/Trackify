using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Comments.Queries.GetCommentById;

public record GetCommentByIdCommand(Guid CommentId) : IRequest<Result<AddCommentDTO>?>;
