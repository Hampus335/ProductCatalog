using ProductCatalog.Products;
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
        public SearchProducts(ApplicationState applicationState)
        {
            InitializeComponent();

            State = applicationState;
        }

        // Correct signature for the Button Click event
        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            var foundProducts = State.Products.Where(p => p.ProductName.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) || p.Description?.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == true);
        }
    }
}
