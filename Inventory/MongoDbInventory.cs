using InventorySystem.DatabseContext;
using InventorySystem.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InventorySystem.Inventory;

public class MongoDbInventory : IInventory
{
    private readonly MongoDbContext _dbContext;

    public MongoDbInventory()
    {
        _dbContext = new();
    }

    public bool Exists(string name)
    {
        var documents = _dbContext.Products.Find(new BsonDocument()).ToList();
        foreach (var product in documents)
        {
            if (product.Name == name)
                return true;
        }
        return false;
    }

    public void AddProduct(Product product)
    {
        var documents = _dbContext.Products.Find(new BsonDocument()).ToList();

        bool prev = Exists(product.Name);
        if (prev)
        {
            Utilites.printError("Product already exists.");
            return;
        }
        _dbContext.Products.InsertOne(product);
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        var deleteFilter = Builders<Product>.Filter.Eq("_id", product.Name);
        _dbContext.Products.DeleteOne(deleteFilter);
    }

    public Product? GetProduct(string name)
    {
        var filter = Builders<Product>.Filter.Eq("_id", name);
        return _dbContext.Products.Find(filter).First();
        
    }

    public void PrintInventory()
    {
        var documents = _dbContext.Products.Find(new BsonDocument()).ToList();

        foreach (Product product in documents)
        {
            product.PrintProduct();
        }
    }

    public void EditProduct(Product product, String? description, double price)
    {
        var filter = Builders<Product>.Filter.Eq("_id", product.Name);

        if (description != "" && description != null)
        {
            var update = Builders<Product>.Update.Set("Description", description);
            _dbContext.Products.UpdateOne(filter, update);
        }
        if (price != -1)
        {
            var update = Builders<Product>.Update.Set("Price", price);
            _dbContext.Products.UpdateOne(filter, update);
        }
    }
}