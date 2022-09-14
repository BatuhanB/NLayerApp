﻿using System.Linq.Expressions;

namespace NLayerApp.Core.Services;

public interface IService<T> where T : class,new()
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task RemoveRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}