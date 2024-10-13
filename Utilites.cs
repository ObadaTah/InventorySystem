using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem;

    internal static class Utilites
    {
        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Print Inventory");
            Console.WriteLine("4. Edit Product");
            Console.WriteLine("5. Look For a Product");
            Console.WriteLine("6. Exit");
        }

        public static int GetMenuChoice()
        {
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    return choice;
                }
                else
                {
                    printError("Invalid choice. Please try again.");
                }
            }
        }

        public static Product getProductDetails()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter product description: ");
            string? description = Console.ReadLine();
            double price = GetProductPrice();
            return new Product(name, description, price);
        }

        public static double GetProductPrice()
        {
            while (true)
            {
                Console.Write("Enter product price: ");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    return price;
                }
                else
                {
                    printError("Invalid price. Please try again.");
                }
            }
        }
    private static Product? AskUserForProductName(Inventory inventory, string purpose)
    {
        Console.Write($"Enter product name to {purpose}: ");
        string? name = Console.ReadLine();

        if (name == null || name.Length == 0)
        {

            printError("Invalid name. Please try again.");
            return null;
        }

        Product? product = inventory.GetProduct(name);

        if (product == null)
        {

            printError("Product not found.");
            return null;
        }

        return product;
    }
    internal static void RemoveProductAction(Inventory inventory)
    {
        Product? product = AskUserForProductName(inventory, "removev");
        inventory.RemoveProduct(product);
    }

    internal static void EditProduct(Inventory inventory)
    {
        Product? product = AskUserForProductName(inventory, "edit");

        if (product == null)
        {
            return;
        }

        Console.Write("Enter products new name / Leave empty to keep the same: ");
        string? name = Console.ReadLine();

        // Check if the name already exists in the inventory
        if (name != "" && name != null)
        {
            bool prev = inventory.Exists(name);
            if (prev)
            {
                printError("Product with that name already exists.");
                return;
            }
        }
        Console.Write("Enter product new description / Leave empty to keep the same: ");
        string? description = Console.ReadLine();
        Console.WriteLine("Enter -1 to keep the same");
        double price = GetProductPrice();
    
        product?.EditProduct(name, description, price);

    }

    internal static void Search(Inventory inventory)
    {
        Product? product = AskUserForProductName(inventory, "search");
        product?.PrintProduct();
    }

    internal static void printError(string message)
    {
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(message);

        Console.ResetColor();
        Console.WriteLine();

    }

}

