using ProductCatalog.Products;
namespace ProductCatalog.Services;
    
public class ProductService : IProductService
{
    public IFileService FileService { get; private set; }
    public List<Product> Products { get; set; }
    public ProductService(IFileService fileService, List<Product> productList)
    {
        FileService = fileService;
        Products = productList;
    }
    public void RemoveProduct(Guid Id)
    {
        
    }
    public Product EditProduct(Guid Id)
    {
        Product product = Products.FirstOrDefault(p => p.ID == Id);
        return product;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        FileService.SaveData(Products);
    }
}
