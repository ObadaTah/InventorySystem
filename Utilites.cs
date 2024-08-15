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
                    Console.WriteLine("Invalid choice. Please try again.");
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
                    Console.WriteLine("Invalid price. Please try again.");
                }
            }
        }
    private static Product? AskUserForProductName(Inventory inventory, string purpose)
    {
        Console.Write($"Enter product name to {purpose}: ");
        string? name = Console.ReadLine();

        if (name == null || name.Length == 0)
        {
            Console.WriteLine("Invalid name. Please try again.");
            return null;
        }

        Product? product = inventory.GetProduct(name);

        if (product == null)
        {
            Console.WriteLine("Product not found.");
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

        Console.Write("Enter products new name / Leave empty to keep the same: ");
        string? name = Console.ReadLine();

        Product? prev = inventory.GetProduct(name);
        if (prev != null)
        {
            Console.WriteLine("Product with that name already exists.");
            return;
        }

        Console.Write("Enter product new description / Leave empty to keep the same: ");
        string? description = Console.ReadLine();
        Console.WriteLine("Enter -1 to keep the same");
        double price = GetProductPrice();
    
        product?.EditProduct(name, description, price);

    }
}

