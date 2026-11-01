using System;
using System.Collections.Generic;
using System.Text;
using CashRegisterApplication.Models;
using System.Globalization;
using System.IO;

namespace CashRegisterApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product? FindById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(products);
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Product file not found");
                return;
            }
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(';');

                if (parts.Length != 4)
                    continue;

                if (!int.TryParse(parts[0], out int id)) 
                    continue;

                string name = parts[1];

                if (!decimal.TryParse(parts[2],
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal price))
                    continue;

                if (!Enum.TryParse(parts[3], out PriceType pricetype))
                    continue;

                try
                {
                    Product product = new Product(id, name, price, pricetype);
                    AddProduct(product);

                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"Invalid product: {ex.Message}");
                }
            }
        }
    }
}
