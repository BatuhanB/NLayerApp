using NLayerApp.Core.Concretes;

namespace NLayerApp.Core.Repositories.Abstracts;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategory();
}