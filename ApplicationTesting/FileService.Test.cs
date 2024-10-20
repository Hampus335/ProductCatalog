using ProductCatalog.Enums;
using ProductCatalog.Products;
using ProductCatalog.Services;

namespace ProductCatalog.Test;

public class FileServiceTest
{
    private readonly string _tempDataFilePath = "SavedProducts.json";
    [Fact]
    public void SaveAndLoadData_ShouldSaveAndReadProductFromFile()
    {
        // Arrange  
        var fileService = new FileService();

        IList<Product> productsToSave = new List<Product>
        {
            new Product(Guid.NewGuid(), "Guitar", Categories.Category.MusicEquipment, 300m, "Electric guitar"),
            new Product(Guid.NewGuid(), "Drum Set", Categories.Category.MusicEquipment, 500m, "Full drum set")
        };

        // act - Save products to a temporary file
        fileService.SaveData(productsToSave, "SavedProducts.json");

        // assert - Ensure file was saved successfully
        Assert.True(File.Exists(_tempDataFilePath), "Data file should exist after saving.");

        // act - Load products from the file
        var loadedProducts = fileService.LoadData("SavedProducts.json").Result;

        // assert - Check that loaded products match saved products
        Assert.NotNull(loadedProducts);
        Assert.Equal(productsToSave.Count, loadedProducts.Count);
        Assert.Equal(productsToSave[0].ProductName, loadedProducts[0].ProductName);
        Assert.Equal(productsToSave[1].ProductName, loadedProducts[1].ProductName);

        File.Delete(_tempDataFilePath);
    }

    [Fact]
    public async Task LoadData_ReturnsTrueWhenFileIsMissing()
    {
        // arrange
        var fileService = new FileService();
        var invalidFilePath = @"C:/this/path/does/not/exist";

        // act - Try to load products from an invalid path
        var loadedProducts = fileService.LoadData(invalidFilePath);

        // assert
        Assert.False(loadedProducts.Succeeded);
        Assert.Null(loadedProducts.Result);
    }
}
