using System;
using System.Collections.Generic;
using System.Text;
using CashRegisterApplication.Repositories;

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
                        Console.WriteLine("New customer started");
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
    }
}
