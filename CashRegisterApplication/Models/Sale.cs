using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.Models
{
    public class Sale
    {
        private readonly List<SaleItem> items = new List<SaleItem>();

        public void AddItem(Product product, decimal quantity)
        {
            SaleItem item = new SaleItem(product, quantity);
            items.Add(item);

        }

        public decimal GetTotal()
        {
            return items.Sum(item => item.TotalPrice);
        }

        public List<SaleItem> GetItems()
        {
            return new List<SaleItem>(items);
        }
    }
}
