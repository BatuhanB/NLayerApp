using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.API.Filters;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
	[ValidateFilter]
	public class ProductsController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public ProductsController(IMapper mapper, IProductService productService)
		{
			_mapper = mapper;
			_productService = productService;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetProductsWithCategory()
		{
			return CreateActionResult(await _productService.GetProductsWithCategory());
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productService.GetAllAsync();
			var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
			return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
		}

		[ServiceFilter(typeof(NotFoundFilter<Product>))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			var productsDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
		}

		[HttpPost]
		public async Task<IActionResult> Save(ProductDto productDto)
		{
			var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
			var productsDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
		{
			await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
			//var noContent = NoContentDto.Success(204, "Product has been successfully updated");
			var noContent = CustomResponseDto<NoContentDto>.Success(204);
			return CreateActionResult(noContent);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			await _productService.RemoveAsync(product);
			var noContent = CustomResponseDto<NoContentDto>.Success(204);
			return CreateActionResult(noContent);
		}
	}
}
