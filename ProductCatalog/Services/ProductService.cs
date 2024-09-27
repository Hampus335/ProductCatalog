using ProductCatalog.Products;
using System.Linq;
namespace ProductCatalog.Services;

public class ProductService
{
    internal IReadOnlyList<Product> ProductList { get; set; }
    public ProductService(IReadOnlyList<Product> productList)
    {
        ProductList = productList;
    }
    internal void RemoveProduct(Guid Id)
    {

    }
    internal Product EditProduct(Guid Id)
    {
        Product product = ProductList.FirstOrDefault(p => p.ID == Id);
        return product;
    }
}
