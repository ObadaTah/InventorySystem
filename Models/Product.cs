using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using ThirdParty.Json.LitJson;

namespace InventorySystem.Models;

public class Product
{
    [Key]
    [BsonId]
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Product(string name, string description, double price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public void PrintProduct()
    {
        Console.WriteLine($"Name: {Name}, Description: {Description}, Price: {Price}");
    }


}