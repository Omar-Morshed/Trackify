using System;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Infrastructure.Repository.Implementation;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {}
}
