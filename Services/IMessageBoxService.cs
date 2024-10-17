namespace ProductCatalog.Services;

public interface IMessageBoxService
{
    void Show(string message, string caption);
}