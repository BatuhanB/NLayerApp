﻿using System.Xml.Linq;

namespace NLayerApp.Core.Concretes;

public class ProductFeature
{
    public ProductFeature()
    {
        
    }

    public int Id { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}