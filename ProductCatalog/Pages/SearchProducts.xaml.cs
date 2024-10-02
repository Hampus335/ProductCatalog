using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Pages;

public partial class SearchProducts : Page
{
    protected ProductService _ProductService { get; set; }
    public SearchProducts(ProductService productService)
    {
        InitializeComponent();
        _ProductService = productService;
    }

    // Runs when search button is clicked
    private void SearchProduct(object sender, RoutedEventArgs e)
    {
        //Got help from ChatGPT with the following line 
        var foundProducts = _ProductService.Products.Where(p => p.ProductName.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) || p.Description?.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == true);
        ResultsListBox.ItemsSource = foundProducts;
    }

    // Runs when item in listbox is selected
    private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedProduct = ResultsListBox.SelectedItem;
        ButtonEdit.IsEnabled = true;
        ButtonRemove.IsEnabled = true;
    }

    private void EditProduct(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ResultsListBox.SelectedItem as Product;
    }

    private void ConfirmRemoval(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            Product? selectedProduct = ResultsListBox.SelectedItem as Product;
            _ProductService.RemoveProduct(selectedProduct.ID);
        }
    }
}
