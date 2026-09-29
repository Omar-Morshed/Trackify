using Microsoft.EntityFrameworkCore;
using Trackify.Application.Interface;
using Task = Trackify.Domain.Entities.Tasks.Task;
using TaskStatus = Trackify.Domain.Enums.TaskStatus;
namespace Trackify.Infrastructure.Repository.Implementation;

public class TaskRepository : GenericRepository<Task>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    { }

    public override async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await dbSet.Include(task => task.Project).ToListAsync();
    }
    public override async Task<Task?> GetByIdAsync(Guid id)
    {
        return await dbSet.Include(task => task.Project).FirstOrDefaultAsync(task => task.Id == id);
    }
}
