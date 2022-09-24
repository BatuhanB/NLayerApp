using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoriesController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryService.GetAllAsync();
			var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
			return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
		}

		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> GetSingleCategoryByIdWithProductAsync(int id)
		{
			var result = await _categoryService.GetSingleCategoryByIdWithProductAsync(id);
			return CreateActionResult(result);
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> CategoriesWithProducts()
		{
			var result = await _categoryService.GetAllCategoriesWithProductsAsync();
			return CreateActionResult(result);
		}

		[HttpPost]
		public async Task<IActionResult> Save(CategoryDto categoryDto)
		{
			var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
			var categoriesDto = _mapper.Map<CategoryDto>(category);
			var response = CustomResponseDto<CategoryDto>.Success(201, categoriesDto);
			return CreateActionResult(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _categoryService.GetByIdAsync(id);
			var categoryDto = _mapper.Map<CategoryDto>(category);
			return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
		{
			await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var deletedCategory = await _categoryService.GetByIdAsync(id);
			await _categoryService.RemoveAsync(deletedCategory);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}

	}
}
