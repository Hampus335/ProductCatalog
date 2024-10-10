using ProductCatalog.Products;
using System.Windows.Controls;

namespace ProductCatalog.Services;
    
public class ProductService : IProductService
{
    public IFileService FileService { get; set; }
    public List<Product> Products { get; set; }
    public ProductService(IFileService fileService)
    {
        FileService = fileService;
        if (null != fileService.LoadData().Result)
        {
            Products = fileService.LoadData().Result!;
        }
        else
        {
            Products = new List<Product>();
        }
    }

    public List<Product> GetProducts()
    {
        return Products;
    }
    public void RemoveProduct(Guid Id)
    {
        Product? product = Products.FirstOrDefault(p => p.ID == Id);
        Products.Remove(product);
        FileService.SaveData(Products);
    }
    public void OpenEditPage(Guid Id, Frame mainFrame, AddProductPage addProductPage)
    { 
        Product? product = Products.FirstOrDefault(p => p.ID == Id);
        Action<Product?> onProductSaved = (editedProduct) =>
        {
            if (editedProduct != null)
            {
                // Update the existing product in the list if it exists
                var existingProduct = Products.FirstOrDefault(p => p.ID == editedProduct.ID);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = editedProduct.ProductName;
                    existingProduct.Category = editedProduct.Category;
                    existingProduct.Price = editedProduct.Price;
                    existingProduct.Description = editedProduct.Description;

                    // Save the updated product list
                    FileService.SaveData(Products);
                }
            }
        };
        mainFrame.NavigationService.Navigate(new AddProductPage(this, product, onProductSaved));
    }

    public void AddProduct(Product product)
    {
        if (Products.Any(p => p.ID == product.ID))
        {
            return;
        }
        Products.Add(product);
        FileService.SaveData(Products);
    }
}
