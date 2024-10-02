using ProductCatalog.Products;
using System.Collections.Generic;

namespace ProductCatalog.Services;

public interface IProductService
{
    void RemoveProduct(Guid Id);
    Product EditProduct(Guid Id);
}
