using ProductCatalog.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace ProductCatalog.Services;

public partial class RemoveAllProducts : Page
{
    public ObservableCollection<Product> Products { get; set; }
    public IFileService FileService { get; private set; }

    public RemoveAllProducts(IProductService productService, IFileService fileService)
    {
        Products = productService.GetProducts();
        FileService = fileService;
        ConfirmProductRemoval();
    }

    public void ConfirmProductRemoval()
    {
        MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (MessageBoxResult.Yes == result)
        {
            RemoveProducts();
        }
        else return;
    }

    public void RemoveProducts()
    {
        Products.Clear();
        FileService.SaveData(Products);
    }
}
