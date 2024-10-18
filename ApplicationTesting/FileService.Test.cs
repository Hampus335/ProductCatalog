﻿using Moq;
using ProductCatalog.Enums;
using ProductCatalog.Products;
using ProductCatalog.Services;

namespace ProductCatalog.Test;

public class FileServiceTest
{
    private readonly FileService _fileService = new();
    private readonly MessageBoxService messageBoxService = new();
    private readonly string _tempDataFilePath = Path.Combine(Path.GetTempPath(), "SavedProducts.json");

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
        _fileService.SaveData(products);

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
        _fileService.SaveData(products);

        ProductService productService = new ProductService(_fileService, messageBoxService);

        var listLengthBeforeProductRemove = productService.Products.Count;

        // Act
        productService.RemoveProduct(productService.Products[0].ID);

        // Assert
        Assert.Equal(listLengthBeforeProductRemove - 1, productService.Products.Count);
    }

    [Fact]
    public void UpdateProduct_ShouldModifyExistingProduct()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        var productToEdit = new Product(Guid.NewGuid(), "Old Name", Categories.Category.Toys, 100m, "desc");
        var updatedProduct = new Product(productToEdit.ID, "New Name", Categories.Category.MusicEquipment, 150m, "new desc");

        var productService = new ProductService(mockFileService.Object, new Mock<IMessageBoxService>().Object);
        productService.AddProduct(productToEdit); 

        // Act
        productService.UpdateProduct(updatedProduct);

        // Assert
        var updated = productService.GetProducts().FirstOrDefault(p => p.ID == productToEdit.ID);
        Assert.Equal("New Name", updated?.ProductName);
        Assert.Equal(150m, updated?.Price);
        Assert.Equal(Categories.Category.MusicEquipment, updated?.Category);
        Assert.Equal("new desc", updated?.Description);

        // Verify file save
        mockFileService.Verify(s => s.SaveData(It.IsAny<List<Product>>()), Times.Once);
    }

    [Fact]
    public void SaveData_ShouldSaveProductsToFile_AndLoadData_ShouldReadFromFile()
    {
        // Arrange  
        var fileService = new FileService();

        IList<Product> productsToSave = new List<Product>
        {
            new Product(Guid.NewGuid(), "Guitar", Categories.Category.MusicEquipment, 299.99m, "Electric guitar"),
            new Product(Guid.NewGuid(), "Drum Set", Categories.Category.MusicEquipment, 499.99m, "Full drum set")
        };

        // Act - Save products to a temporary file
        fileService.SaveData(productsToSave);

        // Assert - Ensure file was saved successfully
        Assert.True(File.Exists(_tempDataFilePath), "Data file should exist after saving.");

        // Act - Load products from the file
        var loadedProducts = fileService.LoadData().Result;

        // Assert - Check that loaded products match saved products
        Assert.NotNull(loadedProducts);
        Assert.Equal(productsToSave.Count, loadedProducts.Count);
        Assert.Equal(productsToSave[0].ProductName, loadedProducts[0].ProductName);
        Assert.Equal(productsToSave[1].ProductName, loadedProducts[1].ProductName);

        // Clean up by deleting the temp file
        File.Delete(_tempDataFilePath);
    }


    private readonly string _tempOriginFilePath = Path.Combine(Path.GetTempPath(), "TempOrigin.json");

    [Fact]
    public void SaveOrigin_ShouldSaveOriginToFile_AndLoadOrigin_ShouldReadFromFile()
    {
        // Arrange
        var fileService = new FileService();
        string originToSave = "USA";

        // Act - Save origin to a temporary file
        fileService.SaveOrigin(originToSave);

        // Assert - Ensure file was saved successfully
        Assert.True(File.Exists(_tempOriginFilePath), "Origin file should exist after saving.");

        // Act - Load origin from the file
        var loadedOrigin = fileService.LoadOrigin().Result;

        // Assert - Check that loaded origin matches saved origin
        Assert.NotNull(loadedOrigin);
        Assert.Equal(originToSave, loadedOrigin);

        // Clean up by deleting the temp file
        File.Delete(_tempOriginFilePath);
    }
}
