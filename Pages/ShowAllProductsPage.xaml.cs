using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace ProductCatalog.Pages;
/// <summary>
/// Interaction logic for ShowAllProductsPage.xaml
/// </summary>
public partial class ShowAllProductsPage : Page
{
    public IProductService ProductService { get; set; }
    public ObservableCollection<Product> Products { get; set; }
    public Frame MainFrame { get; set; }
    private AddProductPage AddProductPage { get; set; }


    public ShowAllProductsPage(IProductService productService, Frame mainFrame, AddProductPage addProductPage)
    {
        InitializeComponent();
        ProductService = productService;
        Products = productService.GetProducts();
        MainFrame = mainFrame;
        AddProductPage = addProductPage;
        this.DataContext = this;
    } 
    private void ListBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        ProductActions.SelectionChanged(ListBoxProducts, ButtonEdit, ButtonRemove, ProductName, ProductPrice, ProductCategory, ProductDescription, ProductID);
    }
    private void EditProduct(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ListBoxProducts.SelectedItem as Product;
        ProductActions.EditProduct(selectedProduct, ProductService, MainFrame, AddProductPage);
    }

    private void ConfirmRemoval(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ListBoxProducts.SelectedItem as Product;
        ProductActions.ConfirmRemoval(selectedProduct, ProductService);
    }
}