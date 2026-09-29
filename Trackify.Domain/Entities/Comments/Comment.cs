using System;
using Trackify.Domain.Entities.Tasks;
using Task = Trackify.Domain.Entities.Tasks.Task;
namespace Trackify.Domain.Entities.Comments;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
}
