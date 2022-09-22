using AutoMapper;
using Microsoft.AspNetCore.Http;
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
            var response = CustomResponseDto<CategoryDto>.Success(200, categoriesDto);
            return CreateActionResult(response);

        }
    }
}
