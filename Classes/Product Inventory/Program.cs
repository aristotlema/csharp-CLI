using System;
using System.Collections.Generic;

/*Product Inventory Project - 
 * Create an application which manages an inventory of products. Create a product class which has a price, id, and quantity on hand. 
 * Then create an inventory class which keeps track of various products and can sum up the inventory value.*/

namespace Product_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inv = new();

            /*inv.EnterNewProduct()*/;

            inv.ListAllProducts();
            Console.WriteLine(inv.CalculateTotalValue());

            inv.CreateNewProduct("Magazine", 4.99, 600);
            inv.ListAllProducts();
            Console.WriteLine(inv.CalculateTotalValue());
        }
    }

    public class Inventory
    {
        private int IdCounter = 1;
        private List<Product> Products { get; } = new List<Product>();

        public Inventory()
        {
            CreateNewProduct("Comic Books", 10.29, 50);
            CreateNewProduct("Hard Cover", 30.56, 9);
            CreateNewProduct("Encyclopedia", 99.99, 3);
        }
        private int GenerateId() => IdCounter++;

        public void CreateNewProduct(string name, double price, int quantity)
        {
            Products.Add(new(GenerateId(), name, price, quantity));
        }
        public void EnterNewProduct()
        {
            Console.Write("Name: ");
            string inputName = Console.ReadLine();
            Console.Write("Price ");
            string inputPrice = Console.ReadLine();
            double parsePrice = Double.Parse(inputPrice);
            Console.Write("Quantity ");
            string inputQuantity = Console.ReadLine();
            int parseQuantity = Int32.Parse(inputQuantity);

            CreateNewProduct(inputName, parsePrice, parseQuantity);
        }
        public void ListAllProducts()
        {
            foreach(var product in Products)
                product.PrintProductDetails(product);
        }
        public double CalculateTotalValue()
        {
            double total = 0;
            foreach(var product in Products)
            {
                total += product.GetProductPrice() * product.GetProductQuantity();
            }
            return total;
        }
    }
    public class Product
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private double Price { get; set; }
        private int Quantity { get; set; }

        public Product(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double GetProductPrice() => Price;
        public int GetProductQuantity() => Quantity;
        public void PrintProductDetails(Product product)
        {
            Console.WriteLine($"{Id} - {Name} - {Price} - {Quantity}");
        }
    }
}
