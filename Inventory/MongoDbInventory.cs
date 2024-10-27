using InventorySystem.DatabseContext;

namespace InventorySystem.Inventory;

public class MongoDbInventory
{
    public MongoDbContext DbContext;

    public MongoDbInventory()
    {
        DbContext = new();
    }
}