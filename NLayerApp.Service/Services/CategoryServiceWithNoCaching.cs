using AutoMapper;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Repositories.Abstracts;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;

namespace NLayerApp.Service.Services;

public class CategoryServiceWithNoCaching : Service<Category>, ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	public CategoryServiceWithNoCaching(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository) : base(unitOfWork, repository)
	{
		_mapper = mapper;
		_categoryRepository = categoryRepository;
	}

	public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
	{
		var category = await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);
		var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
		return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
	}

	public async Task<CustomResponseDto<List<CategoryWithProductDto>>> GetAllCategoriesWithProductsAsync()
	{
		var categories = await _categoryRepository.GetCategoriesWithProducts();
		var categoriesDto = _mapper.Map<List<CategoryWithProductDto>>(categories);
		return CustomResponseDto<List<CategoryWithProductDto>>.Success(200, categoriesDto);
	}
}