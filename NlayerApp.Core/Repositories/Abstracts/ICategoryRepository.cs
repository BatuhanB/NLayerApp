using NLayerApp.Core.Concretes;

namespace NLayerApp.Core.Repositories.Abstracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
	Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryId);
	Task<List<Category>> GetCategoriesWithProducts();
}