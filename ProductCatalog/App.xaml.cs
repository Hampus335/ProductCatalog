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
        internal void App_Startup(object sender, StartupEventArgs e)
        {
            State = new(DataManagement.LoadData());
        }
    }
}