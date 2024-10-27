
using InventorySystem.Inventory;
using InventorySystem.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InventorySystem.Repositories;

public class MongoDbProductRepository : IProductRepository
{
    private readonly MongoDbInventory _inventory = new();

    public bool Exists(string name)
    {
        var documents = _inventory.DbContext.Products.Find(new BsonDocument()).ToList();
        foreach (var product in documents)
        {
            if (product.Name == name)
                return true;
        }
        return false;
    }

    public void AddProduct(Product product)
    {
        var documents = _inventory.DbContext.Products.Find(new BsonDocument()).ToList();

        bool prev = Exists(product.Name);
        if (prev)
            throw new ArgumentException("Product Name Already Exists");

        _inventory.DbContext.Products.InsertOne(product);
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        var deleteFilter = Builders<Product>.Filter.Eq("_id", product.Name);
        _inventory.DbContext.Products.DeleteOne(deleteFilter);
    }

    public Product? GetProduct(string name)
    {
        var filter = Builders<Product>.Filter.Eq("_id", name);
        return _inventory.DbContext.Products.Find(filter).First();
    }

    public void PrintInventory()
    {
        var documents = _inventory.DbContext.Products.Find(new BsonDocument()).ToList();

        foreach (Product product in documents)
        {
            product.PrintProduct();
        }
    }

    public void EditProduct(Product product, String? name, String? description, double price)
    {
        var filter = Builders<Product>.Filter.Eq(e => e.Name, product.Name);
        var updates = new List<UpdateDefinition<Product>>();
        if (description != "" && description != null)
        {
            updates.Add(Builders<Product>.Update.Set(e => e.Description, description));
        }

        if (description != "" && description != null)
        {
            updates.Add(Builders<Product>.Update.Set(e => e.Name, name));
        }

        if (price != -1)
        {
            updates.Add(Builders<Product>.Update.Set(e => e.Price, price));
        }
        if (updates.Count != 0)
            _inventory.DbContext.Products.UpdateMany(filter, Builders<Product>.Update.Combine(updates));

    }
}