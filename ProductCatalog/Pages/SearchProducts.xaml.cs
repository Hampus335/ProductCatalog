using ProductCatalog.Products;
using ProductCatalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ProductCatalog.Pages
{
    public partial class SearchProducts : Page
    {
        protected ApplicationState State { get; private set; }
        protected ProductService ProductService { get; set; }
        public SearchProducts(ApplicationState applicationState)
        {
            InitializeComponent();

            State = applicationState;
        }

        // Runs when search button is clicked
        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            //Got help from ChatGPT with the following line 
            var foundProducts = State.Products.Where(p => p.ProductName.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) || p.Description?.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == true);
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

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Product? selectedProduct = ResultsListBox.SelectedItem as Product;
                ProductService.RemoveProduct(selectedProduct.ID);
            }
        }
    }
}
