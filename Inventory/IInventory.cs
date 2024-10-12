namespace InventorySystem.Inventory
{
    public interface IInventory
    {
        void AddProduct(Product product);

        bool Exists(string name);

        Product? GetProduct(string name);

        void PrintInventory();

        void RemoveProduct(Product? product);

        void EditProduct(Product product, String? name, String? Description, double Price);
    }
}