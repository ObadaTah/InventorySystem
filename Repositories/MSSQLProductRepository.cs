
using InventorySystem.Inventory;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Repositories;

public class MSSQLProductRepository : IProductRepository
{
    private readonly MSSQLInventory _inventory = new();

    public bool Exists(string name)
    {
        foreach (var product in _inventory.DbContext.Product)
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
            throw new ArgumentException("Product name already exists.");

        _inventory.DbContext.Product.Add(product);
        _inventory.DbContext.SaveChanges();
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        _inventory.DbContext.Product.Remove(product);
        _inventory.DbContext.SaveChanges();
    }

    public Product? GetProduct(string name)
    {
        return _inventory.DbContext.Product.Find(name);
    }

    public void PrintInventory()
    {
        foreach (Product product in _inventory.DbContext.Product)
        {
            product.PrintProduct();
        }
    }

    public void EditProduct(Product product, String? name, String? description, double price)
    {

        if (description != "" && description != null)
        {
            product.Description = description;
        }
        if (name != "" && name != null)
        {
            product.Name = name;
        }
        if (price != -1)
        {
            product.Price = price;
        }

        if (_inventory.DbContext.ChangeTracker.Entries().Any(e => e.State == EntityState.Modified))
            _inventory.DbContext.SaveChanges();
    }
}