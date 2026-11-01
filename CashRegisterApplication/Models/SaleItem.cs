using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.Models
{
    public class SaleItem
    {
        public Product Product { get; }
        public decimal Quantity { get;  }

        public decimal TotalPrice
        {
            get { return Product.Price * Quantity; }

        }

        public SaleItem(Product product, decimal quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity has to be over 0");

            if (product.PriceType == PriceType.Per && quantity != decimal.Truncate(quantity))
                throw new ArgumentException("Products cannot have decimal quantities");

            Product = product;
            Quantity = quantity;
        }
    }
}
