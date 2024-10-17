using ProductCatalog.Models;
using ProductCatalog.Products;
using System.Collections.ObjectModel;

namespace ProductCatalog.Services;

public interface IFileService
{
    ResultResponse<List<Product>> LoadData();
    void SaveData(IList<Product> productList);
    ResultResponse<String> LoadOrigin();
    void SaveOrigin(string origin);
}