using System;

namespace Trackify.Application.Interface;

public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }
    ITaskRepository TaskRepository { get; }
    ICommentRepository CommentRepository { get; }
    int Save();
    Task<int> SaveAsync();
}
