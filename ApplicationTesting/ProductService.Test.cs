using Moq;
using ProductCatalog.Enums;
using ProductCatalog.Models;
using ProductCatalog.Products;
using ProductCatalog.Services;

namespace ProductCatalog.Test;

public class ProductServiceTest
{
    private readonly FileService _fileService = new();
    private readonly MessageBoxService messageBoxService = new();

    [Fact]
    public void ProductList_Should_Be_One_More()
    {
        // Arrange
        IList<Product> products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Laptop", Categories.Category.Clothing, 1200.99m, "High-performance laptop for work and gaming"),
            new Product(Guid.NewGuid(), "T-shirt", Categories.Category.Toys, 19.99m, "Comfortable cotton t-shirt"),
            new Product(Guid.NewGuid(), "Pizza", Categories.Category.Electronics, 8.99m, "Delicious cheese pizza with extra toppings")
        };

        // Simulate the file service saving the list of products
        _fileService.SaveData(products, "SavedProducts.json");

        ProductService productService = new ProductService(_fileService, messageBoxService);

        var listLengthBeforeProductAdd = products.Count;

        // Act
        var newProduct = new Product(Guid.NewGuid(), "Audi R8", Categories.Category.Cars, 8.99m, "Nice car");
        productService.AddProduct(newProduct);

        // Mock the behavior of saving the updated list with the new product added
        products.Add(newProduct); 

        // Assert
        Assert.Equal(listLengthBeforeProductAdd + 1, products.Count);
    }


    [Fact]
    public void ProductList_Should_Be_One_Less()
    {
        // Arrange
        IList<Product> products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Laptop", Categories.Category.Clothing, 1200.99m, "High-performance laptop for work and gaming"),
            new Product(Guid.NewGuid(), "T-shirt", Categories.Category.Toys, 19.99m, "Comfortable cotton t-shirt"),
            new Product(Guid.NewGuid(), "Pizza", Categories.Category.Electronics, 8.99m, "Delicious cheese pizza with extra toppings")
        };

        // Simulate the file service saving the list of products
        _fileService.SaveData(products, "SavedProducts.json");

        ProductService productService = new ProductService(_fileService, messageBoxService);

        var listLengthBeforeProductRemove = productService.Products.Count;

        // Act
        productService.RemoveProduct(productService.Products[0].ID);

        // Assert
        Assert.Equal(listLengthBeforeProductRemove - 1, productService.Products.Count);
    }

    [Fact]
    public void EditProduct_ShouldUpdateProductDetails()
    {
        // Arrange
        var mockProductService = new Mock<IProductService>();
        var mockFileService = new Mock<IFileService>();

        var productToEdit = new Product(Guid.NewGuid(), "Old Name", Categories.Category.Toys, 100m, "desc");

        var updatedProduct = new Product(productToEdit.ID, "New Name", Categories.Category.MusicEquipment, 150m, "desc");

        var resultResponse = new ResultResponse<List<Product>>(true, null, null) { Result = new List<Product> { productToEdit } };
        mockFileService.Setup(s => s.LoadData("SavedProducts.json")).Returns(resultResponse);

        mockProductService.Setup(s => s.GetProducts()).Returns(new List<Product> { productToEdit });

        // Act
        var productService = new ProductService(mockFileService.Object, new Mock<IMessageBoxService>().Object);
        productService.UpdateProduct(updatedProduct);

        // Assert
        var updated = productService.GetProducts().FirstOrDefault(p => p.ID == productToEdit.ID);
        Assert.Equal("New Name", updated?.ProductName);
        Assert.Equal(150m, updated?.Price);
        Assert.Equal(Categories.Category.MusicEquipment, updated?.Category);

        // Verify that file saving happens
        mockFileService.Verify(s => s.SaveData(It.IsAny<List<Product>>(), "SavedProducts.json"), Times.Once);
    }
}
