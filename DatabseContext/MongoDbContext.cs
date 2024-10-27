using InventorySystem.Models;
using MongoDB.Driver;

namespace InventorySystem.DatabseContext;

public class MongoDbContext
{
    public readonly IMongoCollection<Product> Products;

    public MongoDbContext()
    {
        var mongoPassword = System.Environment.GetEnvironmentVariable("MONGO_PASSWORD");
        MongoClient dbClient = new MongoClient($"mongodb+srv://obadatahboub20:{mongoPassword}@simpleinventory.tn5o6.mongodb.net/?retryWrites=true&w=majority&appName=simpleInventory");

        var dbList = dbClient.ListDatabases().ToList();
        var database = dbClient.GetDatabase("simple_inventory");

        Products = database.GetCollection<Product>("products");
    }
}