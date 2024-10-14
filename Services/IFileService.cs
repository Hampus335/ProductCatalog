using ProductCatalog.Models;
using ProductCatalog.Products;
using System.Collections.ObjectModel;

namespace ProductCatalog.Services;

public interface IFileService
{
    ResultResponse<ObservableCollection<Product>> LoadData();
    void SaveData(IList<Product> productList);
}