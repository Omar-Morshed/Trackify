using System;

namespace Trackify.Application.Features.Comments.DTOs;

public record AddCommentDTO(string Content, Guid TaskId);
