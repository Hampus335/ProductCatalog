using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Pages;

/// <summary>
/// Interaction logic for RemoveAllProducts.xaml
/// </summary>
public partial class RemoveAllProducts : Page
{
    public List<Product> Products { get; set; }
    public IFileService FileService { get; private set; }

    public RemoveAllProducts(IProductService productService, IFileService fileService)
    {
        Products = productService.GetProducts();
        FileService = fileService;
        ConfirmProductRemoval();
    }

    public void ConfirmProductRemoval()
    {
        MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (MessageBoxResult.Yes == result)
        {
            RemoveProducts();
        }
        else return;
    }

    public void RemoveProducts()
    {
        Products.Clear();
        FileService.SaveData(Products);
    }
}
