using InventorySystem.DatabseContext;
using InventorySystem.Models;

namespace InventorySystem.Inventory;

public class MSSQLInventory : IInventory
{
    private readonly MSSQLDatabaseContext _dbContext;

    public MSSQLInventory()
    {
        _dbContext = new();
    }

    public bool Exists(string name)
    {
        foreach (var product in _dbContext.Product)
        {
            if (product.Name == name)
                return true;
        }
        return false;
    }

    public void AddProduct(Product product)
    {
        bool prev = Exists(product.Name);
        if (prev)
        {
            Utilites.printError("Product already exists.");
            return;
        }
        _dbContext.Product.Add(product);
        _dbContext.SaveChanges();
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        _dbContext.Product.Remove(product);
        _dbContext.SaveChanges();

    }

    public Product? GetProduct(string name)
    {
        return _dbContext.Product.Find(name);
    }

    public void PrintInventory()
    {
        foreach (Product product in _dbContext.Product)
        {
            product.PrintProduct();
        }
    }

    public void EditProduct(Product product, String? description, double price)
    {
        if (description != "" && description != null)
        {
            product.Description = description;
        }
        if (price != -1)
        {
            product.Price = price;
        }
        _dbContext.SaveChanges();
    }
}