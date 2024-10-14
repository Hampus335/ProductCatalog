using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Pages;

public partial class SearchProducts : Page
{
    protected IProductService ProductService { get; set; }
    public Frame MainFrame { get; set; }
    private AddProductPage AddProductPage { get; set; }
    public SearchProducts(IProductService productService, Frame mainFrame, AddProductPage addProductPage)
    {
        InitializeComponent();
        ProductService = productService;
        MainFrame = mainFrame;
        AddProductPage = addProductPage;
    }

    // Runs when search button is clicked
    private void SearchProduct(object sender, RoutedEventArgs e)
    {
        //Got help from ChatGPT with the following line 
        var foundProducts = ProductService.GetProducts().Where(p => p.ProductName.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) || p.Description?.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == true);
        ResultsListBox.ItemsSource = foundProducts;
    }

    // Runs when item in listbox is selected
    private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ProductActions.SelectionChanged(ResultsListBox, ButtonEdit, ButtonRemove, ProductName, ProductPrice, ProductCategory, ProductDescription, ProductID);
    }

    private void EditProduct(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ResultsListBox.SelectedItem as Product;
        ProductActions.EditProduct(selectedProduct, ProductService, MainFrame, AddProductPage);
    }

    private void ConfirmRemoval(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ResultsListBox.SelectedItem as Product;
        ProductActions.ConfirmRemoval(selectedProduct, ProductService);
    }

}
