using System.Linq.Expressions;
using NLayerApp.Core.Repositories.Abstracts;

namespace NLayerApp.Core.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : class,new()
{
    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
}