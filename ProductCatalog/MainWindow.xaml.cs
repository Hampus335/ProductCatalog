using ProductCatalog.Pages;
using System.Text;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_AddProduct(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AddProductPage());
        }

        private void Button_ShowAllProducts(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new ShowAllProductsPage(App.State));
        }

        private void Button_SaveProducts(object sender, RoutedEventArgs e)
        {

        }

        private void Button_LoadProducts(object sender, RoutedEventArgs e)
        {

        }
    }
}