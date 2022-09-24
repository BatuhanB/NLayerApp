using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.Repositories.Abstracts;

namespace NLayerApp.Repository.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
	public ProductRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<List<Product>> GetProductsWithCategory()
	{
		//Eager Loading
		return await _context.Products.Include(x => x.Category).ToListAsync();
	}
}