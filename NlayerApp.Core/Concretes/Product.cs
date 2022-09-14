using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Product : BaseEntity
{
    public Product()
    {
        
    }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ProductFeature? ProductFeature { get; set; }
}