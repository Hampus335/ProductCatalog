using ProductCatalog.Products;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Services;
    
public class ProductService : IProductService
{
    public IFileService FileService { get; set; }
    public List<Product> Products { get; set; }
    private readonly IMessageBoxService MessageBoxService;

    public ProductService(IFileService fileService, IMessageBoxService messageBoxService)
    {
        MessageBoxService = messageBoxService;
        FileService = fileService;
        if (null != fileService.LoadData().Result)
        {
            Products = fileService.LoadData().Result!;
        }
        else
        {
            Products = new List<Product>();
        }
        MessageBoxService = messageBoxService;
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
    public void OpenEditPage(Guid Id, Frame? mainFrame, AddProductPage? addProductPage)
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
        mainFrame.NavigationService.Navigate(new AddProductPage(this, FileService, product, onProductSaved, mainFrame, null));
    }

    public Product? AddProduct(Product product)
    {
        // If product ID matches, we are editing a product. In that case we don't add a new one
        if (Products.Any(p => p.ID == product.ID))
        {
            return product; // Return the existing product so it will be edited
        }

        // If the product name already exists, we show a message and return null
        if (Products.Any(p => p.ProductName == product.ProductName))
        {
            MessageBoxService.Show("This product name already exists, choose something else.", "Information");
            return null;
        }

        // Add the new product
        Products.Add(product);
        return product;
    }
}
