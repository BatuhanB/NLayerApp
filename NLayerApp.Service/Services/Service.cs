﻿using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Repositories.Abstracts;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using NLayerApp.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayerApp.Service.Services;

public class Service<T> : IService<T> where T : class, new()
{
	private readonly IGenericRepository<T> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
	{
		_unitOfWork = unitOfWork;
		_repository = repository;
	}

	public async Task<T> GetByIdAsync(int id)
	{
		var hasProduct = await _repository.GetByIdAsync(id);
		if (hasProduct == null)
		{
			throw new NotFoundException($"{typeof(T).Name}({id}) not found");
		}

		return hasProduct;
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _repository.GetAll().ToListAsync();
	}

	public IQueryable<T> Where(Expression<Func<T, bool>> expression)
	{
		return _repository.Where(expression);
	}

	public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
	{
		return await _repository.AnyAsync(expression);
	}

	public async Task<T> AddAsync(T entity)
	{
		await _repository.AddAsync(entity);
		await _unitOfWork.CommitAsync();
		return entity;
	}

	public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
	{
		var addRangeAsync = entities as T[] ?? entities.ToArray();
		await _repository.AddRangeAsync(addRangeAsync);
		await _unitOfWork.CommitAsync();
		return addRangeAsync;
	}

	public async Task RemoveRangeAsync(IEnumerable<T> entities)
	{
		_repository.RemoveRange(entities);
		await _unitOfWork.CommitAsync();

	}

	public async Task UpdateAsync(T entity)
	{
		_repository.Update(entity);
		await _unitOfWork.CommitAsync();
	}

	public async Task RemoveAsync(T entity)
	{
		_repository.Remove(entity);
		await _unitOfWork.CommitAsync();
	}
}