using Accessibility;
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

namespace ProductCatalog.Pages;

/// <summary>
/// Interaction logic for ShowAllProductsPage.xaml
/// </summary>
public partial class ShowAllProductsPage : Page
{
    private readonly ApplicationState _currentState;
    public ShowAllProductsPage(ApplicationState currentState)
    {
        InitializeComponent();
        _currentState = currentState;
    }

    public void LoadProducts(ApplicationState currentState)
    {
             
    }
}