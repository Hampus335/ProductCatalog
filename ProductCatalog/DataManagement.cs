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
    public static List<Products.Product> LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            string jsonString = File.ReadAllText(DataFilePath);
            var savedProducts = JsonSerializer.Deserialize<List<Products.Product>>(jsonString);
            return savedProducts!;
        }
        else
        {
            File.WriteAllText(DataFilePath, "[]");
            return new List<Products.Product>();
        }
    }

    public static void SaveData(IReadOnlyList<Products.Product> productList)
    {
        if (File.Exists(DataFilePath))
        {
            string productString = JsonSerializer.Serialize(productList);
            File.WriteAllText(DataFilePath, productString);
        }
        else
        {
            File.WriteAllText(DataFilePath, "[]");
        }
    }
}