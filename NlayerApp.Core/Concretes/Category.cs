using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Category : BaseEntity
{
    public Category(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public string Name { get; set; }
    public Product? Product { get; set; }
}