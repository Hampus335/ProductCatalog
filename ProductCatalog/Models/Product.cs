using ProductCatalog.Enums;

namespace ProductCatalog.Products;
public class Product
{
    public Guid ID { get; set; }
    public string ProductName { get; set; }
    public Categories.Category Category { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public Product(string productName, Categories.Category chosenCategory, decimal price, string? description)
    {
        ID = Guid.NewGuid();  // Generates an unique ID
        ProductName = productName;
        Category = chosenCategory;
        Price = price;
        Description = description!;
    }
}
