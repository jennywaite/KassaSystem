using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CashRegisterApplication.Models;
using CashRegisterApplication.Repositories;
using System.IO;
using CashRegisterApplication.Services;

namespace CashRegisterApplication.UI
{
    public class ConsoleUI
    {

        private readonly IProductRepository repository;

        public ConsoleUI(IProductRepository repository)
        {
            this.repository = repository;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("==== Cash Register System ====");
                Console.WriteLine("1. New customer");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose an alternative: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        NewCustomer();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid alternative");
                        break;
                }

            }
        }

        public void NewCustomer()
        {
            Sale sale = new Sale();

            Console.WriteLine("New customer started");
            Console.WriteLine("Enter product ID and amount, ex. 101 4");
            Console.WriteLine("Enter PAY to pay or BACK to go back to the menu");

            while (true)
            {
                Console.Write("Product: ");
                string? input = Console.ReadLine();

                if (input == null || input.ToUpper() == "BACK")
                {
                    break;
                }

                    if (input.Equals("PAY", StringComparison.OrdinalIgnoreCase))
                    {
                        if (sale.GetItems().Count == 0)
                        {
                            Console.WriteLine("Sale is empty");
                            continue;
                        }

                        try
                        {
                            ReceiptService receiptService = new ReceiptService();
                            receiptService.SaveReceipt(sale);
                            break;
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Could not save the receipt: {ex.Message}");
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Console.WriteLine($"No access to save receipt: {ex.Message}");
                        }
                        continue;
                    }


                    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 2 || !int.TryParse(parts[0], out int id) || !decimal.TryParse(parts[1],
                        System.Globalization.
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture, out decimal quantity))
                    {
                        Console.WriteLine("Invalid comment.");
                        continue;
                    }

                    Product? product = repository.FindById(id);
               

                if (product == null)
                    {
                        Console.WriteLine("Product doesn't exist");
                        continue;
                    }

                    try
                    {
                        sale.AddItem(product, quantity);
                        Console.WriteLine($"Added: {product.Name}");
                        Console.WriteLine($"Total: {sale.GetTotal():F2} kr");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
            }


            }
        }
    } 

