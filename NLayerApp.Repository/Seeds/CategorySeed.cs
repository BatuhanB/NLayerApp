using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Concretes;

namespace NLayerApp.Repository.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasData(
			new Category { Id = 1, Name = "Ev & Mobilya" },
			new Category { Id = 2, Name = "Kozmetik" },
			new Category { Id = 3, Name = "Saat & Aksesuar" },
			new Category { Id = 4, Name = "Elektronik" },
			new Category { Id = 5, Name = "Sport & Outdoor" });
	}
}