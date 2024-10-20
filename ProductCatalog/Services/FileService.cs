using System.IO;
using System.Text.Json;
using ProductCatalog.Models;
using ProductCatalog.Products;

namespace ProductCatalog.Services;
public class FileService : IFileService
{
    private const string OriginFilePath = "Origin.json";
    public ResultResponse<List<Product>> LoadData(string path)
    {
        if (File.Exists(path))
        {
            try
            {
                var productList = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(path))!;

                return ResultResponse<List<Product>>.Ok(productList);
            }
            catch (Exception)
            {
                return ResultResponse<List<Product>>.Error("Something's wrong!");
            }
        }
        return ResultResponse<List<Product>>.Error("File doesn't exist.");
    }
    public void SaveData(IList<Products.Product> productList, string path)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(path, productString);
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