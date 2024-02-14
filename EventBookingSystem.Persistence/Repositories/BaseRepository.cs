using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories;
using EventBookingSystem.Persistence.Context;
using System.Linq.Expressions;

namespace EventBookingSystem.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _dbContext;
    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BaseRepository()
    {
        _dbContext = new AppDbContext();
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }
    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
        _dbContext.SaveChanges();
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Where(expression);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().OrderBy(c => c.Id).ToList();
    }

    public TEntity GetById(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
        _dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().UpdateRange(entities);
        _dbContext.SaveChanges();
    }
}
