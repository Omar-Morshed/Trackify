using System;

namespace Trackify.Application.Interface;

public interface IGenericRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    Task DeleteAsync(Guid id);
    void Delete(TEntity entity);
}
