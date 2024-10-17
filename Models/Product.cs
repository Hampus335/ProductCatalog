using ProductCatalog.Enums;

namespace ProductCatalog.Products;
    public class Product
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public Categories.Category Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }


    public Product(Guid id, string productName, Categories.Category category, decimal price, string? description)
    {
        ID          = id;
        ProductName = productName;
        Category    = category;
        Price       = price;
        Description = description;
    }   

    public static Product Create(string productName, Categories.Category chosenCategory, decimal price, string? description)
        => new Product(Guid.NewGuid(), productName, chosenCategory, price, description);

    }