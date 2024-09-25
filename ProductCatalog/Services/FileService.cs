using System.IO;
using System.Text.Json;
using ProductCatalog.Models;
using ProductCatalog.Products;

namespace ProductCatalog.Services;
public class FileService
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
            catch (Exception ex)
            {
                return ResultResponse<List<Product>>.Error("Something's wrong!");
            }
        }
        return ResultResponse<List<Product>>.Error("File doesn't exist");
    }
    public void SaveData(IReadOnlyList<Products.Product> productList)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(DataFilePath, productString);
    }
}