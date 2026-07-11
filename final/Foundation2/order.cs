using System;
using System.Collections.Generic;


public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Iterates through products and applies flat shipping logic depending on user residence
    public double CalculateTotalOrderCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.CalculateTotalCost();
        }

        // Add shipping rate flat fees
        double shippingCost = _customer.LivesInUsa() ? 5.00 : 35.00;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";
        foreach (Product product in _products)
        {
            label += $"  - Item: {product.GetName()} [ID: {product.GetProductId()}]\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetFormattedAddress()}\n";
    }
}