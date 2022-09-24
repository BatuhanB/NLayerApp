﻿using AutoMapper;
using NLayerApp.Core.Concretes;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Service.Mapping;

public class MapProfile : Profile
{
	public MapProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
		CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<ProductUpdateDto, Product>();
		CreateMap<Product, ProductWithCategoryDto>();
		CreateMap<Category, CategoryWithProductsDto>();
		CreateMap<Category, CategoryWithProductDto>();
	}

}