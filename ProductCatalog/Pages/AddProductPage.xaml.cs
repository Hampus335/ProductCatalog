using ProductCatalog.Enums;
using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProductCatalog;
public partial class AddProductPage : Page
{
    private ProductService _ProductService { get; set; }
    public AddProductPage()
    {
        InitializeComponent();
        CategoryDropdown.ItemsSource = Enum.GetValues(typeof(Categories.Category));
    }
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled   = regex.IsMatch(e.Text);
    }

    private void AddProduct(object sender, RoutedEventArgs e)
    {
        Product product = Product.Create(ProductNameTextBox.Text, (Categories.Category)CategoryDropdown.SelectedItem, decimal.Parse(ProductPriceTextBox.Text), ProductDescriptionTextBox.Text);
        _ProductService.AddProduct(product);
    }
}
    