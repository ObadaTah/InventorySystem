using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    class Inventory
    {
        List<Product> Products { get; set; }

        public Inventory()
        {
            Products = new List<Product>();
        }
        public Boolean Exists(string name)
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
    }
}
