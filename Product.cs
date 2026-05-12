using System;

// This class represents a product in the inventory
public class Product
{
    // Product properties
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Constructor for creating a product
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Function to display product information
    public void DisplayProduct()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Price: ${Price}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine("--------------------------");
    }
}