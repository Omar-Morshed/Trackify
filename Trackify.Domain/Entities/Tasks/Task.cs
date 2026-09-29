using System;
using Trackify.Domain.Entities.Comments;
using Trackify.Domain.Entities.Projects;

namespace Trackify.Domain.Entities.Tasks;

using TaskStatus = Enums.TaskStatus;

public class Task : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.Todo;

    //* Relationships
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public List<Comment> Comments { get; set; }

    //* Methods
    public bool ChangeStatus(TaskStatus newStatus)
    {
        if ((Status == TaskStatus.Todo && (newStatus == TaskStatus.InProgress || newStatus == TaskStatus.Cancelled))
        || (Status == TaskStatus.InProgress && (newStatus == TaskStatus.Completed || newStatus == TaskStatus.Cancelled)))
        {
            Status = newStatus;
            return true;
        }

        return false;
    }

}