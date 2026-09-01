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
    public async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity != null)
            dbSet.Remove(entity);
    }

    public void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        return entity ?? null;
    }

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

}
