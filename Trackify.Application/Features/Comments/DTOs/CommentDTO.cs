using System;

namespace Trackify.Application.Features.Comments.DTOs;

using Task = Trackify.Domain.Entities.Task;

public record CommentDTO(string Content, Guid TaskId);
