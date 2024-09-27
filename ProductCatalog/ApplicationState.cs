using ProductCatalog.Products;
using ProductCatalog.Services;


namespace ProductCatalog;

public class ApplicationState
{
    public ApplicationState(List<Product> products, IFileService fileService)
    {
        _products = products;
        _fileService = fileService;
    }

    private readonly List<Product> _products;
    private readonly IFileService _fileService;

    public IReadOnlyList<Product> Products => _products;

    public void AddProduct(Product product)
    {
        _products.Add(product);
        _fileService.SaveData(_products);
    }
}