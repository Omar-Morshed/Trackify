using System;
using MediatR;
using Trackify.Application.Features.Comments.DTOs;
using Trackify.Domain.Abstractions;

namespace Trackify.Application.Features.Comments.Queries.GetTaskComments;

public record GetTaskCommentsCommand(Guid? TaskId) : IRequest<Result<IEnumerable<AddCommentDTO>>>;
