using System;
using System.Runtime.CompilerServices;

public class Product
{
    public string Name;
    public int Price;
    public int Quantity;
    public int Discount;

    // here is constructor overloading

    public Product(string name, int price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
        this.Discount = 0;
    }

    
    public Product(string name, int price, int quantity, int discount)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
        this.Discount = discount;
    }
}

class ProductMain
{
    public static void Run(string[] args)
    {
        Product p1 = new Product("Laptop", 1000, 5);
        Product p2 = new Product("Bag", 100, 15, 10);
        Product p3 = new Product("Book", 10, 35);

        Console.WriteLine(p1.Name + " Price: " + p1.Price);
        Console.WriteLine(p2.Name + " Price after discount: " + (p2.Price - p2.Discount));
        Console.WriteLine(p3.Name + " Price: " + p3.Price);
    }
}