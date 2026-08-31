using System;
using Trackify.Application.Interface;

namespace Trackify.Infrastructure.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProjectRepository ProjectRepository { get; private set; }

    public ITaskRepository TaskRepository { get; private set; }
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        ProjectRepository = new ProjectRepository(context);
        TaskRepository = new TaskRepository(context);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
