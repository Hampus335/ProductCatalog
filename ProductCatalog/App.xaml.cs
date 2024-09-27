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
        public  IFileService FileService = new FileService();
        private readonly Lazy<ProductService> _lazyProductService = new Lazy<ProductService>(() => new ProductService(State.Products));
        public ProductService ProductService => _lazyProductService.Value;
        internal void App_Startup(object sender, StartupEventArgs e)
        {
            var loadResult = FileService.LoadData();

            var data = loadResult.Succeeded
                ? loadResult.Result
                : new List<Product>();
            State = new(data.ToList(), FileService);
        }
    }
}