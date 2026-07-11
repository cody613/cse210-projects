using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("2005 Gamer Way", "Portland", "OR", "USA");
        Customer customer1 = new Customer("Leeroy Jenkins", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("NVIDIA RTX 4090 GPU", "GPU-4090", 1499.99, 1));
        order1.AddProduct(new Product("Corsair 32GB DDR5 RAM", "RAM-32G", 110.50, 2));
        order1.AddProduct(new Product("Intel Core i9-14900K", "CPU-14900", 599.99, 1));

        Address address2 = new Address("42 Wallaby Way", "Sydney", "NSW", "AUS");
        Customer customer2 = new Customer("Leo Williams", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Water-Cooling Loop", "WTR-042", 340.00, 1));
        order2.AddProduct(new Product("Titan Evo Chair", "CHR-TTN", 449.00, 1));
        order2.AddProduct(new Product("240Hz OLED Gaming Monitor", "MON-OLED", 599.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():0.00}\n");

        Console.WriteLine(new string('-', 30) + "\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():0.00}\n");    
    }
}