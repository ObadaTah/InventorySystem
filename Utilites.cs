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
            Console.WriteLine("4. Exit");
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

        public static Product GetProductDetails()
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
    }

