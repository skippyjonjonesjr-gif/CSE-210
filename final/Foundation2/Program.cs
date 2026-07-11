using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Joe Young", address1);
        
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "M102", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "K552", 45.00, 1));
        order1.AddProduct(new Product("Desk Pad", "P900", 12.99, 1));

        Address address2 = new Address("456 Rue de la Paix", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Marie Dubois", address2);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("USB-C Hub", "H320", 35.00, 1));
        order2.AddProduct(new Product("Monitor Stand", "S101", 29.99, 2));

        Console.WriteLine("========================================");
        Console.WriteLine("               ORDER 1                  ");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Order Price: ${order1.CalculateTotalOrderCost():F2}");
        Console.WriteLine();

        Console.WriteLine("========================================");
        Console.WriteLine("               ORDER 2                  ");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Order Price: ${order2.CalculateTotalOrderCost():F2}");
        Console.WriteLine("========================================");
    }
}