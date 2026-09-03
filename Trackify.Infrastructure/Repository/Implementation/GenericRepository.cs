using System;
using Microsoft.EntityFrameworkCore;
using Trackify.Application.Interface;


namespace Trackify.Infrastructure.Repository.Implementation;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    public DbSet<TEntity> dbSet;
    public GenericRepository(DbContext context)
    {
        dbSet = context.Set<TEntity>();
    }
    public virtual void Add(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity != null)
            dbSet.Remove(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        return entity ?? null;
    }

    public virtual void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

}
