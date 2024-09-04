using ProductCatalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductCatalog;

public class ApplicationState
{
    public ApplicationState(List<Product> products)
    {
        _products = products;
    }

    private readonly List<Product> _products;
    public IReadOnlyList<Product> Products => _products;

    public void AddProduct(Product product)
    {
        _products.Add(product);
        DataManagement.SaveData(product);
    }
}