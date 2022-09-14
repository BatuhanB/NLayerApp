﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Concretes;

namespace NLayerApp.Repository;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products{ get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}