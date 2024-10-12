using InventorySystem.Inventory;

namespace InventorySystem;

public class Program
{
    static void Main(string[] args)
    {
        InMemoryInventory inventory = new();
        do
        {
            Utilites.PrintMenu();
            int choice = Utilites.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("///////////// Add New Product /////////////");
                    Product product = Utilites.AskUserProductDetails();
                    inventory.AddProduct(product);
                    break;
                case 2:
                    Console.WriteLine("///////////// Delete a Product /////////////");
                    Utilites.RemoveProductAction(inventory);
                    break;
                case 3:
                    Console.WriteLine("///////////// Print Invevntory /////////////");
                    inventory.PrintInventory();
                    break;
                case 4:
                    Console.WriteLine("///////////// Edit Product /////////////");
                    Utilites.EditProduct(inventory);
                    break;
                case 5:
                    Console.WriteLine("///////////// Search For a Product /////////////");
                    Utilites.Search(inventory);
                    break;
                case 6:
                    Console.WriteLine("///////////// Exit /////////////");

                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }while (true);
    }
}