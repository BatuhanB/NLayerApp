using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Concretes;

namespace NLayerApp.Repository.Configurations;

public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
{
	public void Configure(EntityTypeBuilder<ProductFeature> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).UseIdentityColumn();
		builder.Property(x => x.Color).IsRequired().HasMaxLength(20);
		builder.Property(x => x.Height).IsRequired().HasMaxLength(20);
		builder.Property(x => x.Width).IsRequired().HasMaxLength(20);
		builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
		builder.ToTable("ProductFeatures");
	}
}