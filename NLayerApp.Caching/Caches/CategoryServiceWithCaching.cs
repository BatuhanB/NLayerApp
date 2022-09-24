using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Repositories.Abstracts;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using NLayerApp.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayerApp.Caching.Caches;

public class CategoryServiceWithCaching : ICategoryService
{
	private readonly string CacheStringKey = "CategoryCache";
	private readonly IMapper _mapper;
	private readonly IMemoryCache _cache;
	private readonly ICategoryRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public CategoryServiceWithCaching(IMapper mapper, IMemoryCache cache, ICategoryRepository repository, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_cache = cache;
		_repository = repository;
		_unitOfWork = unitOfWork;

		if (!_cache.TryGetValue(CacheStringKey, out _))
		{
			_cache.Set(CacheStringKey, _repository.GetCategoriesWithProducts().Result);
		}
	}

	public Task<Category> GetByIdAsync(int id)
	{
		var category = _cache.Get<List<Category>>(CacheStringKey).FirstOrDefault(x => x.Id == id);
		if (category == null)
		{
			throw new NotFoundException($"{typeof(Category).Name}({id}) not found");
		}

		return Task.FromResult(category);
	}

	public Task<IEnumerable<Category>> GetAllAsync()
	{
		var categories = _cache.Get<IEnumerable<Category>>(CacheStringKey);
		return Task.FromResult(categories);
	}

	public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
	{
		var query = _cache.Get<List<Category>>(CacheStringKey).Where(expression.Compile()).AsQueryable();
		return query;
	}

	public Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
	{
		return _repository.AnyAsync(expression);
	}

	public async Task<Category> AddAsync(Category entity)
	{
		await _repository.AddAsync(entity);
		await _unitOfWork.CommitAsync();
		await CacheAllCategories();
		return entity;
	}

	public async Task<IEnumerable<Category>> AddRangeAsync(IEnumerable<Category> entities)
	{
		await _repository.AddRangeAsync(entities);
		await _unitOfWork.CommitAsync();
		await CacheAllCategories();
		return entities;
	}

	public async Task RemoveRangeAsync(IEnumerable<Category> entities)
	{
		_repository.RemoveRange(entities);
		await _unitOfWork.CommitAsync();
		await CacheAllCategories();
	}

	public async Task UpdateAsync(Category entity)
	{
		_repository.Update(entity);
		await _unitOfWork.CommitAsync();
		await CacheAllCategories();
	}

	public async Task RemoveAsync(Category entity)
	{
		_repository.Remove(entity);
		await _unitOfWork.CommitAsync();
		await CacheAllCategories();
	}

	public Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
	{
		var categories = _cache.Get<List<Category>>(CacheStringKey).FirstOrDefault(x => x.Id == categoryId);
		var categoriesDto = _mapper.Map<CategoryWithProductsDto>(categories);
		return Task.FromResult(CustomResponseDto<CategoryWithProductsDto>.Success(200, categoriesDto));
	}

	public Task<CustomResponseDto<List<CategoryWithProductDto>>> GetAllCategoriesWithProductsAsync()
	{
		var categories = _cache.Get<IEnumerable<Category>>(CacheStringKey);
		var categoriesWithProduct = _mapper.Map<List<CategoryWithProductDto>>(categories);
		return Task.FromResult(CustomResponseDto<List<CategoryWithProductDto>>.Success(200, categoriesWithProduct));
	}

	public async Task CacheAllCategories()
	{
		_cache.Set(CacheStringKey, await _repository.GetAll().ToListAsync());
	}
}