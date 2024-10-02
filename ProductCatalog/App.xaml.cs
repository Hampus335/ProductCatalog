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
    public static SearchProducts SearchProducts { get; set; } = null!;

    internal void App_Startup(object sender, StartupEventArgs e)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<ProductService>();

        var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetRequiredService<ProductService>();
        Window window = new MainWindow(serviceProvider.GetRequiredService<ProductService>());
    }
}