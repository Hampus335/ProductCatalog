using ProductCatalog.Products;
using System.Windows;
using System.Windows.Controls;


namespace ProductCatalog.Pages;
/// <summary>
/// Interaction logic for ShowAllProductsPage.xaml
/// </summary>
public partial class ShowAllProductsPage : Page
{
    protected ApplicationState State { get; private set; }
    public ShowAllProductsPage(ApplicationState currentState)
    {
        InitializeComponent();
        State       = currentState;
        DataContext = State; 
    }

    private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBoxProducts.SelectedItem is not Product selectedProduct)
        {
            return;
        }
        ProductName.Text        = selectedProduct.ProductName;
        ProductCategory.Text    = selectedProduct.Category.ToString();
        ProductPrice.Text       = selectedProduct.Price.ToString();
        ProductDescription.Text = selectedProduct.Description;
        ProductID.Text          = selectedProduct.ID.ToString();
    } 
}