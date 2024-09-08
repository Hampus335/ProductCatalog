using System.Configuration;
using System.Data;
using System.Windows;

namespace ProductCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApplicationState State { get; set; } = null!;
        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            State = new(DataManagement.LoadData());
        }
    }

}