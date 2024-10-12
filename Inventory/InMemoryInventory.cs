using InventorySystem.Models;

namespace InventorySystem.Inventory;

public class InMemoryInventory : IInventory
{
    List<Product> Products { get; set; }

    public InMemoryInventory()
    {
        Products = new List<Product>();
    }

    public bool Exists(string name)
    {
        return Products.Exists(product => product.Name == name);
    }

    public void AddProduct(Product product)
    {
        bool prev = Exists(product.Name);
        if (prev)
        {
            Utilites.printError("Product already exists.");

            return;
        }
        Products.Add(product);
    }

    public void RemoveProduct(Product? product)
    {
        if (product == null)
            return;
        Products.Remove(product);
    }

    public Product? GetProduct(string name)
    {
        return Products.Find(product => product.Name == name);
    }

    public void PrintInventory()
    {
        foreach (Product product in Products)
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
    }
}