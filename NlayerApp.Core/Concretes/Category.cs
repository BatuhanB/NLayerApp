using System.Runtime.CompilerServices;
using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Category : BaseEntity
{
    //public Category(string name)
    //{
    //    Name = name ?? throw new ArgumentNullException(nameof(name));
    //}
    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}