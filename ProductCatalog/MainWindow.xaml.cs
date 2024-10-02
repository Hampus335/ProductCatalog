using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Pages;
using ProductCatalog.Services;
using System.Windows;

namespace ProductCatalog;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ProductService ProductService;
    public MainWindow(ProductService productService)
    {
        InitializeComponent();
        ProductService = productService;
    }
    private void Button_AddProduct(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new AddProductPage());
    }

    private void Button_ShowAllProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new ShowAllProductsPage());
    }

    private void Button_SearchProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new SearchProducts(ProductService));
    }

    private void Button_RemoveProducts(object sender, RoutedEventArgs e)
    {

    }
}