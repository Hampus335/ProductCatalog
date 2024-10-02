using ProductCatalog.Models;
using ProductCatalog.Products;

namespace ProductCatalog.Services;

public interface IFileService
{
    ResultResponse<List<Product>> LoadData();
    void SaveData(IReadOnlyList<Product> productList);
}