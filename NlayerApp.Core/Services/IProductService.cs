using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Core.Services;

public interface IProductService:IService<Product>
{
    Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
}