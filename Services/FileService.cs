using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using ProductCatalog.Models;
using ProductCatalog.Products;

namespace ProductCatalog.Services;
public class FileService : IFileService
{
    private const string DataFilePath = "SavedProducts.json";
    public ResultResponse<List<Product>> LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            try
            {
                var productList = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(DataFilePath))!;

                return ResultResponse<List<Product>>.Ok(productList);
            }
            catch (Exception)
            {
                return ResultResponse<List<Product>>.Error("Something's wrong!");
            }
        }
        return ResultResponse<List<Product>>.Error("File doesn't exist");
    }
    public void SaveData(IList<Products.Product> productList)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(DataFilePath, productString);
    }
}