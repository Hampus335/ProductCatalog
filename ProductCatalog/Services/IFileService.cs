using ProductCatalog.Models;
using ProductCatalog.Products;
using System.Collections.ObjectModel;

namespace ProductCatalog.Services;

public interface IFileService
{
    ResultResponse<List<Product>> LoadData(string path);
    void SaveData(IList<Product> productList, string path);
    ResultResponse<String> LoadOrigin();
    void SaveOrigin(string origin);
}