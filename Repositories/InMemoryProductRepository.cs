using InventorySystem.Inventory;
using InventorySystem.Models;

namespace InventorySystem.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly InMemoryInventory Inventory = new InMemoryInventory();
    public bool Exists(string name)
    {
        return Inventory.Products.Exists(product => product.Name == name);
    }

    public void AddProduct(Product product)
    {
        bool prev = Exists(product.Name);
        if (prev)
            throw new ArgumentException("Product Name Already Exists");

        Inventory.Products.Add(product);
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        Inventory.Products.Remove(product);
    }

    public Product? GetProduct(string name)
    {
        return Inventory.Products.Find(product => product.Name == name);
    }

    public void PrintInventory()
    {
        foreach (Product product in Inventory.Products)
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
    }
}