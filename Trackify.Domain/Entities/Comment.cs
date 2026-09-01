using System;

namespace Trackify.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
}
