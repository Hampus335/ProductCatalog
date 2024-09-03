namespace ProductCatalog.Products;

public enum Category
{
    Elektronik,
    Möbler,
    Kläder,
    Musikutrustning
}
public class Product
{
    Guid ID { get; set; }
    string ProductName { get; set; }
    Category Category { get; set; }
    decimal Price { get; set; }
    string? Description { get; set; }

    public Product(string productName, Object category, decimal price, string? description)
    {
        ID = Guid.NewGuid();  // Generates an unique ID
        ProductName = productName;
        Category = (Category)category;
        Price = price;
        Description = description!;
    }
}
