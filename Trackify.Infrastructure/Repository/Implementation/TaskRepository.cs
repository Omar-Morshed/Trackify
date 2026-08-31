using Trackify.Application.Interface;
namespace Trackify.Infrastructure.Repository.Implementation;

public class TaskRepository : GenericRepository<Domain.Entities.Task> , ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {}
}
