using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProductCatalog;
static class DataManagement
{
    private const string DataFilePath = "SavedProducts.json";
    public static List<Products.Product> LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            try
            { 
                return JsonSerializer.Deserialize<List<Products.Product>>(File.ReadAllText(DataFilePath))!;
            }

            catch (Exception ex)
            {
                return new List<Products.Product>();
            }               
        }
        return new List<Products.Product>();
    }
    public static void SaveData(IReadOnlyList<Products.Product> productList)
    {
        string productString = JsonSerializer.Serialize(productList);
        File.WriteAllText(DataFilePath, productString);
    }
}