using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");

        // Create addresses
        Address address1 = new Address("789 Pine St", "RacoonTown", "CA", "USA");
        Address address2 = new Address("321 Oak St", "Detroit", "BC", "Canada");

        // Create customers
        Customer customer1 = new Customer("Jospeh Smith", address1);
        Customer customer2 = new Customer("Chris Prath", address2);

        // Create products
        Product product1 = new Product("Smartphone - Iphone", "SMT456", 999, 1);
        Product product2 = new Product("Tablet - Lenovo", "TBL789", 850, 3);
        Product product3 = new Product("Headphones - Sony", "HDP123", 450, 2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine($"Shipping Cost: ${order1.GetShippingCost()}");
        Console.WriteLine($"Total Quantity: {order1.GetTotalQuantity()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
        Console.WriteLine($"Shipping Cost: ${order2.GetShippingCost()}");
        Console.WriteLine($"Total Quantity: {order2.GetTotalQuantity()}");
    }
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public int GetQuantity()
    {
        return quantity;
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public double GetShippingCost()
    {
        return customer.IsInUSA() ? 5 : 35;
    }

    public int GetTotalQuantity()
    {
        int totalQuantity = 0;
        foreach (var product in products)
        {
            totalQuantity += product.GetQuantity();
        }
        return totalQuantity;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.GetName()} ({product.GetProductId()}) - Quantity: {product.GetQuantity()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}
