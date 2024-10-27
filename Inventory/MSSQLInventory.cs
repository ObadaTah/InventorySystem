using InventorySystem.DatabseContext;

namespace InventorySystem.Inventory;

public class MSSQLInventory
{
    public MSSQLDatabaseContext DbContext;

    public MSSQLInventory()
    {
        DbContext = new();
    }
}