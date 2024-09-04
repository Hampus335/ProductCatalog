using ProductCatalog.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductCatalog;
static class DataManagement
{
    private const string DataFilePath = "SavedProducts.json";
    public static void LoadData()
    {
        string jsonString = File.ReadAllText(DataFilePath);
        var savedProducts = JsonSerializer.Deserialize<Product>(jsonString);
    }

    public static void SaveData(Product product)
    {
        string productString = JsonSerializer.Serialize(product);
        File.WriteAllText(DataFilePath, productString);
    }
}
