using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CashRegisterApplication.Models
{
    public enum PriceType
    {
        Per,
        Kg
    }
    public class Product
    {

        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public PriceType PriceType { get; }

        public Product(int id, string name, decimal price, PriceType priceType)
        {
            if (id == 0) 
                throw new ArgumentException("Not a valid ID");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is missing");

            if (price < 0)
                throw new ArgumentException("Product price cann't be negative");

            if (!Enum.IsDefined(typeof(PriceType), priceType))
                throw new ArgumentException("Invalid price type.");

            Id = id;
            Name = name;
            Price = price;
            PriceType = priceType;
        }
    }
}
