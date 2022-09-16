using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Product : BaseEntity
{
    public Product(int id, DateTime createdDate, DateTime? updatedDate, string name, decimal price, int stock,
        int categoryId, Category? category, ProductFeature? productFeature) : base(id, createdDate, updatedDate)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        Category = category;
        ProductFeature = productFeature;
    }

    public Product() : base()
    {

    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ProductFeature? ProductFeature { get; set; }


}