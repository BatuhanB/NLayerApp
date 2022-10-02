using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Concretes;
using System.Reflection;
using NLayerApp.Core.Abstracts;

namespace NLayerApp.Repository;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductFeature> ProductFeatures { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entityReference)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                    {
                            entityReference.CreatedDate = DateTime.Now;
                            break;
                    }
                    case EntityState.Modified:
                    {
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entityReference)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreatedDate = DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }
            }
        }
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}