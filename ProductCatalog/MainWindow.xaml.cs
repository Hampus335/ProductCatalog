using ProductCatalog.Pages;
using System.Windows;

namespace ProductCatalog;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Button_AddProduct(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new AddProductPage());
    }

    private void Button_ShowAllProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new ShowAllProductsPage(App.State));
    }

    private void Button_SearchProducts(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new SearchProducts(App.State));
    }

    private void Button_RemoveProducts(object sender, RoutedEventArgs e)
    {

    }
}