using System.Runtime.CompilerServices;
using NLayerApp.Core.Abstracts;

namespace NLayerApp.Core.Concretes;

public class Category : BaseEntity
{
    public Category(int id,DateTime createdDate,DateTime updatedDate,string name):base(id, createdDate, updatedDate)
    {
        Id = id;
        CreatedDate = DateTime.Now;
        UpdatedDate = updatedDate;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public Category()
    {
        
    }
    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}