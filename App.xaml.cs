using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Pages;
using ProductCatalog.Services;

namespace ProductCatalog;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    internal void App_Startup(object sender, StartupEventArgs e)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IMessageBoxService, MessageBoxService>();
        services.AddSingleton<IProductService, ProductService>();

        var serviceProvider = services.BuildServiceProvider();
        Window window = new MainWindow(serviceProvider.GetRequiredService<IProductService>(), serviceProvider.GetRequiredService<IFileService>());
        window.Show();
    }
}