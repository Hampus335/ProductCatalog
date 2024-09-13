using ProductCatalog.Enums;
using ProductCatalog.Products;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProductCatalog;
public partial class AddProductPage : Page
{
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
        App.State.AddProduct(product);
    }
}
    