using System;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;
using Trackify.Domain.Entities.Projects;

namespace Trackify.Infrastructure.Repository.Implementation;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {}
}
