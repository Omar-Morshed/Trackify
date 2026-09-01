using System;

namespace Trackify.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
}
