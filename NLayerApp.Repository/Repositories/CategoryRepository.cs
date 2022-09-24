﻿using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.Repositories.Abstracts;

namespace NLayerApp.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryId)
	{
		return (await _context.Categories
			.Include(x => x.Products)
			.Where(x => x.Id == categoryId)
			.SingleOrDefaultAsync())!;
	}

	public async Task<List<Category>> GetCategoriesWithProducts()
	{
		var result = await _context.Categories.Include(x => x.Products).ToListAsync();
		return result;
	}
}