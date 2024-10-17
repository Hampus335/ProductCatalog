using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;


namespace ProductCatalog.Pages;
/// <summary>
/// Interaction logic for ShowAllProductsPage.xaml
/// </summary>
public partial class ShowAllProductsPage : Page
{
    public IProductService ProductService { get; set; }
    public IFileService FileService { get; set; }
    public List<Product> Products { get; set; }
    public Frame MainFrame { get; set; }
    private AddProductPage AddProductPage { get; set; }


    public ShowAllProductsPage(IProductService productService, IFileService fileService, Frame mainFrame, AddProductPage addProductPage, Product? selectedItem)
    {
        InitializeComponent();
        ProductService = productService;
        FileService = fileService;
        Products = productService.GetProducts();
        MainFrame = mainFrame;
        AddProductPage = addProductPage;
        this.DataContext = this;
        if (selectedItem != null)
        {
            ListBoxProducts.SelectedItem = selectedItem;
        }
        else if (Products.Any())
        {
            ListBoxProducts.SelectedItem = Products.First();
        }
    } 
    private void ListBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        ProductActions.SelectionChanged(ListBoxProducts, ButtonEdit, ButtonRemove, ProductName, ProductCategory, ProductPrice, ProductDescription, ProductID);
    }
    private void EditProduct(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ListBoxProducts.SelectedItem as Product;
        ProductActions.EditProduct(selectedProduct, ProductService, MainFrame, AddProductPage);
    }

    private void ConfirmRemoval(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ListBoxProducts.SelectedItem as Product;
        ProductActions.ConfirmRemoval(selectedProduct, ProductService, FileService, "ShowProducts", MainFrame);
    }
}