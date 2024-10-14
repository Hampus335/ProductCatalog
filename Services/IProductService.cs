using ProductCatalog.Products;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProductCatalog.Services;
public interface IProductService
{
    public ObservableCollection<Product> GetProducts();
    void RemoveProduct(Guid Id); 
    void OpenEditPage(Guid Id, Frame mainFrame, AddProductPage addProductPage); 
    void AddProduct(Product product);
} 
