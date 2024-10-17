using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Pages;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IProductService ProductService;
    private IFileService FileService;

    public MainWindow(IProductService productService, IFileService fileService)
    {
        InitializeComponent();
        ProductService = productService;
        FileService = fileService;
    }

    private void Button_AddProduct(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new AddProductPage(ProductService, FileService, null, _ => {}, MainFrame, null));
    }

    private void Button_ShowAllProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new ShowAllProductsPage(ProductService, FileService, MainFrame, new AddProductPage(ProductService, FileService, null, _ => { }, MainFrame, "ShowProducts"), null));
    }

    private void Button_SearchProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new SearchProducts(ProductService, FileService, MainFrame, new AddProductPage(ProductService, FileService, null, _ => { }, MainFrame, "SearchProduct"), null));
    }
    private void Button_RemoveProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new RemoveAllProducts(ProductService, FileService));
    }
}