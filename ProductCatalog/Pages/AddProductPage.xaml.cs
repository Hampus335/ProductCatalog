using ProductCatalog.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace ProductCatalog
{
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            CategoryDropdown.ItemsSource = Enum.GetValues(typeof(Category));
        }
        private void SaveProducts(object sender, RoutedEventArgs e)
        {
            Product product = new Product(ProductNameTextBox.Text, CategoryDropdown.SelectedItem, int.Parse(ProductPriceTextBox.Text), ProductDescriptionTextBox.Text);
        }
    }
}
    