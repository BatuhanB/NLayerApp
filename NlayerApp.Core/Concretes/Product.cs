using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Product : BaseEntity
{
    public Product(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Category>? Category { get; set; }
    public ProductFeature? ProductFeature { get; set; }
}