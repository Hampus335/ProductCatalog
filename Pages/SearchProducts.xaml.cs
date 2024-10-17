using ProductCatalog.Products;
using ProductCatalog.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Pages;

public partial class SearchProducts : Page
{
    protected IProductService ProductService { get; set; }
    private IFileService FileService { get; set; }
    public Frame MainFrame { get; set; }
    private AddProductPage AddProductPage { get; set; }
    public SearchProducts(IProductService productService, IFileService fileService, Frame mainFrame, AddProductPage addProductPage, Product? editedProduct)
    {
        InitializeComponent();
        ProductService = productService;
        FileService = fileService;
        MainFrame = mainFrame;
        AddProductPage = addProductPage;

        if (editedProduct != null)
        {
            SearchBox.Text = editedProduct.ProductName;
            SearchAndDisplayProducts(editedProduct);
        }
    }

    private void SearchAndDisplayProducts(Product? selectedProduct = null)
    {
        // got help from my friend GPT with the following method, however I do understand it.
        var foundProducts = ProductService.GetProducts()
            .Where(p => p.ProductName.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase)
                     || p.Description?.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == true);

        ResultsListBox.ItemsSource = foundProducts;
        if (selectedProduct != null)
        {
            ResultsListBox.SelectedItem = selectedProduct;
        }
    }

    // Runs when the search button is clicked
    private void SearchProduct(object sender, RoutedEventArgs e)
    {
        SearchAndDisplayProducts();
    }


    // Runs when item in listbox is selected
    private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ProductActions.SelectionChanged(ResultsListBox, ButtonEdit, ButtonRemove, ProductName, ProductCategory, ProductPrice, ProductDescription, ProductID);
    }

    private void EditProduct(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ResultsListBox.SelectedItem as Product;
        ProductActions.EditProduct(selectedProduct, ProductService, MainFrame, AddProductPage);
    }

    private void ConfirmRemoval(object sender, RoutedEventArgs e)
    {
        Product? selectedProduct = ResultsListBox.SelectedItem as Product;
        ProductActions.ConfirmRemoval(selectedProduct, ProductService, FileService, "SearchProducts", MainFrame);
    }

}
