using CashRegisterApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace CashRegisterApplication.Services
{
    public class ReceiptService
    {
        public void SaveReceipt(Sale sale)
        {
            StringBuilder receipt = new StringBuilder();

            receipt.AppendLine("========= RECEIPT =========");
            receipt.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ");
            receipt.AppendLine();

            foreach (SaleItem item in sale.GetItems())
            {
                receipt.AppendLine(
                    $"{item.Product.Name} - " +
                    $"{item.Quantity} x {item.Product.Price:F2} = " +
                    $"{item.TotalPrice:F2} kr");


            }

            receipt.AppendLine();
            receipt.AppendLine($"TOTAL: {sale.GetTotal():F2} kr");
            receipt.AppendLine("===================================");
            receipt.AppendLine();

            string fileName = $"RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            string filePath = Path.Combine(AppContext.BaseDirectory, fileName);

            File.AppendAllText(filePath, receipt.ToString());

            Console.WriteLine(receipt.ToString());
            Console.WriteLine("Receipt saved successfully.");
        }

    }
}
