using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Concretes;

namespace NLayerApp.Repository.Seeds;

public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasData(
            new ProductFeature { Id = 1, Color = "Mavi", Height = 12, Width = 5,ProductId = 1},
            new ProductFeature { Id = 2, Color = "Beyaz", Height = 8, Width = 3, ProductId = 2},
            new ProductFeature { Id = 3, Color = "Gri", Height = 4, Width = 4,ProductId = 3},
            new ProductFeature { Id = 4, Color = "Siyah", Height = 15, Width = 6,ProductId = 4},
            new ProductFeature { Id = 5, Color = "Kahverengi", Height = 20, Width = 18,ProductId = 5});
    }
}