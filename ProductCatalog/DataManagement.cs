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
    public static Object LoadData()
    {
        string jsonString = File.ReadAllText(DataFilePath);
        var savedProducts = JsonSerializer.Deserialize<Product>(jsonString);
        return savedProducts!;
    }

    public static void SaveData(IReadOnlyList<Product> productList)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(DataFilePath, productString);
    }
}
