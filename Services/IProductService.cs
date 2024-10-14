using ProductCatalog.Products;
using System.Windows.Controls;

namespace ProductCatalog.Services;
public interface IProductService
{
    public List<Product> GetProducts();
    void RemoveProduct(Guid Id); 
    void OpenEditPage(Guid Id, Frame mainFrame, AddProductPage addProductPage); 
    void AddProduct(Product product);
} 
