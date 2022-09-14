using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Category : BaseEntity
{
    public Category(string? name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public Category()
    {
        throw new NotImplementedException();
    }

    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}