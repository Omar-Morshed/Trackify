using System;

namespace Trackify.Application.Interface;

public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }
    ITaskRepository TaskRepository { get; }
    int Save();
    Task<int> SaveAsync();
}
