using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // ===== FIRST ORDER =====
        //products:
        Product p1 = new Product("Mouse", "M001", 25.99, 2);
        Product p2 = new Product("Keyboard", "K002", 45.50, 1);
        List<Product> products1 = new List<Product> {p1,p2};

        //address and customer
        Address direccion1 = new Address("Street 123", "Popayan", "cauca", "Colombia");
        Customer client1 = new Customer("Ana Mosquera", direccion1);

        //order
        Order order1 = new Order(products1, client1);

        //show information
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total: ${order1.GetTotalPrice()}\n");


        // ===== SECOND ORDER =====
        //products:
        Product p3 = new Product("Laptop", "L003", 825.00, 1);
        Product p4 = new Product("Earphones", "E002", 65.00, 2);
        List<Product> products2 = new List<Product> {p3,p4};

        //address and customer
        Address direccion2 = new Address("123 Main St", "Salt Lake City", "Utah", "USA");
        Customer client2 = new Customer("John Smith", direccion2);

        //order
        Order order2 = new Order(products2, client2);

        //show information
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.GetTotalPrice()}\n");
    }
}