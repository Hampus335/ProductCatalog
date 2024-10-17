using ProductCatalog.Pages;
using ProductCatalog.Products;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalog.Services;

public static class ProductActions
{
    public static void SelectionChanged(ListBox resultsListBox, Button buttonEdit, Button buttonRemove, TextBlock productName, TextBlock productCategory, TextBlock productPrice, TextBlock productDescription, TextBlock productID)
    {
        if (resultsListBox.SelectedItem is not Product selectedProduct)
        {
            return;
        }
        productName.Text = selectedProduct.ProductName;
        productCategory.DataContext = selectedProduct.Category;
        productCategory.Text = selectedProduct.Category.ToString();
        productPrice.Text = selectedProduct.Price.ToString();
        productDescription.Text = selectedProduct.Description;
        productID.Text = selectedProduct.ID.ToString();

        buttonEdit.IsEnabled = true;
        buttonRemove.IsEnabled = true;
    }
    public static void EditProduct(Product selectedProduct, IProductService productService, Frame mainFrame, AddProductPage addProductPage)
    {
        productService.OpenEditPage(selectedProduct.ID, mainFrame, addProductPage);
    }

    public static void ConfirmRemoval(Product selectedProduct, IProductService productService, IFileService fileService, string origin, Frame mainFrame)
    {
        if (selectedProduct != null)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                productService.RemoveProduct(selectedProduct.ID);

                if (origin == "ShowProducts")
                {
                    mainFrame.NavigationService.Navigate(new ShowAllProductsPage(productService, fileService, mainFrame, new AddProductPage(productService, fileService, null, null, mainFrame, null), null));
                }
                else if (origin == "SearchProducts")
                {
                    mainFrame.NavigationService.Navigate(new SearchProducts(productService, fileService, mainFrame, new AddProductPage(productService, fileService, null, null, mainFrame, null), null));
                }
            }
        }
    }
}
