using InventorySystem.Models;

namespace InventorySystem.Repositories;

public interface IProductRepository
{
    void AddProduct(Product product);

    bool Exists(string name);

    Product? GetProduct(string name);

    void PrintInventory();

    void RemoveProduct(Product? product);

    void EditProduct(Product product, String? Name, String? Description, double Price);
}
