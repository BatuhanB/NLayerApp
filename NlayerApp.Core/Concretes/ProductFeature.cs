namespace NLayerApp.Core.Concretes;

public class ProductFeature
{
    public ProductFeature()
    {

    }
    public ProductFeature(int id, string color, int height, int width, int productId, Product? product)
    {
        Id = id;
        Color = color;
        Height = height;
        Width = width;
        ProductId = productId;
        Product = product;
    }
    public int Id { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}