﻿using NLayerApp.Core.Concretes;
using System.Linq.Expressions;

namespace NLayerApp.Core.Services;

public interface IService<T> where T : class,new()
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task RemoveRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}