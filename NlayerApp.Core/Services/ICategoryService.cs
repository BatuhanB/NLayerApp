using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Core.Services;

public interface ICategoryService:IService<Category>
{
    Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);
    Task<CustomResponseDto<List<CategoryWithProductDto>>> GetAllCategoriesWithProductsAsync();
}