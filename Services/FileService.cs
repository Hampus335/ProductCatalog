using System.IO;
using System.Text.Json;
using ProductCatalog.Models;
using ProductCatalog.Products;

namespace ProductCatalog.Services;
public class FileService : IFileService
{
    private const string DataFilePath = "SavedProducts.json";
    private const string OriginFilePath = "Origin.json";
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
        return ResultResponse<List<Product>>.Error("File doesn't exist.");
    }
    public void SaveData(IList<Products.Product> productList)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(DataFilePath, productString);
    }

    public ResultResponse<String> LoadOrigin()
    {
        if (File.Exists(OriginFilePath))
        {
            try
            {
                var origin = JsonSerializer.Deserialize<string>(File.ReadAllText(OriginFilePath))!;

                return ResultResponse<String>.Ok(origin);
            }
            catch (Exception)
            {
                return ResultResponse<String>.Error("Something went wrong when reading from the file.");
            }
        }
        return ResultResponse<String>.Error("File doesn't exist.");
    }
    public void SaveOrigin(string origin)
    {
        string originString = JsonSerializer.Serialize(origin);
        File.WriteAllText(OriginFilePath, originString);
    }
}