using Microsoft.EntityFrameworkCore;
using Trackify.Domain.Entities;

namespace Trackify.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        AuditLogs();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AuditLogs();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AuditLogs()
    {
        var entities = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
        foreach(var entity in entities)
        {
            if(entity.State == EntityState.Added)
                entity.Property(e => e.CreatedAt).CurrentValue = DateTime.UtcNow;
            //* Changing the Update Date when Updating an Entity that uses the `BaseEntity` Class
            entity.Property(e => e.UpdatedAt).CurrentValue = DateTime.UtcNow;
        }
    }
}