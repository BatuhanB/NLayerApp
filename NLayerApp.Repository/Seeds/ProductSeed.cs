using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Concretes;

namespace NLayerApp.Repository.Seeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product { Id = 1, Name = "LAV Bardak Seti", Price = 160, Stock = 120, CategoryId = 1},
            new Product { Id = 1, Name = "Laventin Cilt Beyazlatici Krem", Price = 108, Stock = 242, CategoryId = 2 },
            new Product { Id = 1, Name = "Casio A159wa-n1df Erkek Kol Saati", Price = 370, Stock = 58, CategoryId = 3 },
            new Product { Id = 1, Name = "Apple Iphone 11 64GB", Price = 15549, Stock = 87, CategoryId = 4 },
            new Product { Id = 1, Name = "Protein Ocean Whey Protein", Price = 172, Stock = 1200, CategoryId = 5 });
    }
}