using System;

namespace Trackify.Domain.Entities;

public class Task : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public List<Comment> Comments { get; set; }
}