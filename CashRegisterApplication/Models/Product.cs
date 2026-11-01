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
          
        }
    }
}
