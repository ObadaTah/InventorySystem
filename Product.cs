namespace InventorySystem;

public class Product
{
    public string Name { get ; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Product(string name, string description, double price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public void PrintProduct()
    {
        Console.WriteLine($"Name: {Name}, Description: {Description}, Price: {Price}");
    }

    internal void EditProduct(string? name, string? description, double price)
    {
        if (name != "" && name != null)
        {
            this.Name = name;
        }
        if (description != "" && description != null)
        {
            this.Description = description;
        }
        if (price != -1)
        {
            this.Price = price;
        }
    }
}