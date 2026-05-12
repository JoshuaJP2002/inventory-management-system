using System;
using System.Collections.Generic;
using System.IO;

// Main inventory management program
class Program
{
    // List to store all products
    static List<Product> inventory = new List<Product>();

    static void Main(string[] args)
    {
        bool running = true;

        // Main program loop
        while (running)
        {
            Console.WriteLine("\n=== Inventory Management System ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product Quantity");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Save Inventory");
            Console.WriteLine("6. Load Inventory");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            // Conditional statements for menu options
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    ViewProducts();
                    break;

                case "3":
                    UpdateProduct();
                    break;

                case "4":
                    RemoveProduct();
                    break;

                case "5":
                SaveToFile();
                break;

                case "6":
                LoadFromFile();
                break;

                case "7":
                running = false;
                Console.WriteLine("Exiting program...");
                break;
            }
        }
    }

    // Function to add a new product
    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter product quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product product = new Product(name, price, quantity);

        inventory.Add(product);

        Console.WriteLine("Product added successfully.");
    }

    // Function to display all products
    static void ViewProducts()
    {
        Console.WriteLine("\n=== Product List ===");

        double totalValue = 0;

        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
        }
        else
        {
            foreach (Product product in inventory)
            {
                product.DisplayProduct();

                //Expression to calculate total inventory value
                totalValue += product.Price * product.Quantity;

                //using structure
                ProductInfo info = new ProductInfo(product.Name, product.Quantity);
                info.DisplayInfo();
            }

            Console.WriteLine($"Total Inventory Value: ${totalValue}");
        }

    }

    // Function to update product quantity
    static void UpdateProduct()
    {
        Console.Write("Enter product name to update: ");
        string name = Console.ReadLine();

        foreach (Product product in inventory)
        {
            if (product.Name.ToLower() == name.ToLower())
            {
                Console.Write("Enter new quantity: ");
                product.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Quantity updated.");
                return;
            }
        }

        Console.WriteLine("Product not found.");
    }

    // Function to remove a product
    static void RemoveProduct()
    {
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine();

        foreach (Product product in inventory)
        {
            if (product.Name.ToLower() == name.ToLower())
            {
                inventory.Remove(product);

                Console.WriteLine("Product removed.");
                return;
            }
        }

        Console.WriteLine("Product not found.");
    }

    // Function to save inventory to a file
    static void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter("inventory.txt"))
        {
        foreach (Product product in inventory)
        {
            writer.WriteLine($"{product.Name},{product.Price},{product.Quantity}");
        }
    }

    Console.WriteLine("Inventory saved to file.");
}

// Function to load inventory from a file
    static void LoadFromFile()
    {
        if (File.Exists("inventory.txt"))
    {
        string[] lines = File.ReadAllLines("inventory.txt");

        inventory.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            string name = parts[0];
            double price = Convert.ToDouble(parts[1]);
            int quantity = Convert.ToInt32(parts[2]);

            Product product = new Product(name, price, quantity);

            inventory.Add(product);
        }

        Console.WriteLine("Inventory loaded from file.");
        }
        else
        {
            Console.WriteLine("No inventory file found.");
        }
    }
}
