using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;

namespace Trackify.Application.Features.Comments.Queries.GetTaskComments;

public record GetTaskCommentsCommand(Guid? TaskId) : IRequest<IEnumerable<CommentDTO>>;
