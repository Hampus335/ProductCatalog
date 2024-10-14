using ProductCatalog.Enums;
using ProductCatalog.Pages;
using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;


namespace ProductCatalog;
public partial class AddProductPage : Page
{
    private IProductService ProductService { get; set; }
    private Product? Product { get; set; }
    private bool IsEditing { get; set; }
    private Action<Product?> OnProductSaved { get; set; }
    private Frame MainFrame { get; set; }

    public AddProductPage(IProductService productService, Product? product, Action<Product?> onProductSaved, Frame mainFrame)
    {
        InitializeComponent();
        if (EditProduct(product))
        {
            CheckAndReadProduct(product);
        }
        CategoryDropdown.ItemsSource = Enum.GetValues(typeof(Categories.Category));
        ProductService = productService;
        OnProductSaved = onProductSaved;
        MainFrame = mainFrame;
    }

    public void CheckAndReadProduct(Product product)
    {
        Product = product;
        ProductNameTextBox.Text = Product.ProductName;
        CategoryDropdown.DataContext = Product.Category;
        CategoryDropdown.Text = Product.Category.ToString();
        ProductPriceTextBox.Text = Product.Price.ToString();
        ProductDescriptionTextBox.Text = Product.Description;
    }

    private bool EditProduct(Product? product)
    {
        if (product != null)
        {
            IsEditing = true;
            Title.Text = "Edit Product";
            return true;
        }
        else return false;
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
        Regex regex = new Regex("[^0-9]+");
        e.Handled   = regex.IsMatch(e.Text);
    }

    private void AddProduct(object sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text))
            {
                MessageBox.Show("Productname can not be null");
                return;
            }

            if (CategoryDropdown.SelectedItem == null && IsEditing == false)
            {
                MessageBox.Show("You need to choose a category");
                return;
            }

            if (!decimal.TryParse(ProductPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("You need a price");
                return;
            }


            if (IsEditing)
            {
                Product.ProductName = ProductNameTextBox.Text;
                Product.Category = (Categories.Category)CategoryDropdown.DataContext;
                Product.Price = decimal.Parse(ProductPriceTextBox.Text);
                Product.Description = ProductDescriptionTextBox.Text;

                //save product changes on edited product
                OnProductSaved?.Invoke(Product);
            }
            else
            {
                Product = Product.Create(ProductNameTextBox.Text,
                                             (Categories.Category)CategoryDropdown.SelectedItem,
                                             price,
                                             ProductDescriptionTextBox.Text);
            }

            if (Product == null)
            {
                MessageBox.Show("Could not add the product, please try again.");
                return;
            }

            else
            {
                ProductService.AddProduct(Product);
                OnProductSaved?.Invoke(null);
                if (NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.Navigate(new ShowAllProductsPage(ProductService, MainFrame, new AddProductPage(ProductService, null, _ => { }, MainFrame)));
                    NavigationService.GoBack();
                }
            }
        }   
        catch (Exception ex)
        {
            MessageBox.Show($"Ett fel uppstod: {ex.Message}");
        }
    }
}
