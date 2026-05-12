using System;

// Structure to store product summary information
public struct ProductInfo
{
    public string ProductName;
    public int ProductQuantity;

    // Constructor
    public ProductInfo(string name, int quantity)
    {
        ProductName = name;
        ProductQuantity = quantity;
    }

    // Display summary information
    public void DisplayInfo()
    {
        Console.WriteLine($"Product: {ProductName} | Quantity: {ProductQuantity}");
    }
}