using System.Windows;

namespace ProductCatalog.Services;

public class MessageBoxService : IMessageBoxService
{
    public void Show(string message, string caption)
    {
        MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
