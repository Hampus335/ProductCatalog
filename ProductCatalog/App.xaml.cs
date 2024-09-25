using System.Windows;
using ProductCatalog.Products;
using ProductCatalog.Services;

namespace ProductCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApplicationState State { get; set; } = null!;
        public  FileService fileService = new FileService();
        internal void App_Startup(object sender, StartupEventArgs e)
        {
            var loadResult = fileService.LoadData();

            var data = loadResult.Succeeded
                ? loadResult.Result
                : new List<Product>();
            State = new(data.ToList(), fileService);
        }
    }
}