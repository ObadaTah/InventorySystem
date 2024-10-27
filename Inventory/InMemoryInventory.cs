using InventorySystem.Models;

namespace InventorySystem.Inventory;

public class InMemoryInventory
{
    public List<Product> Products { get; set; }

    public InMemoryInventory()
    {
        Products = new List<Product>();
    }
}