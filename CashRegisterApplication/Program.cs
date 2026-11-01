using CashRegisterApplication.Repositories;
using CashRegisterApplication.UI;
using System;

namespace CashRegisterSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductRepository repository = new ProductRepository();

            string filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "products.txt"
                );

            repository.LoadFromFile(filePath);

            ConsoleUI ui = new ConsoleUI(repository);
            ui.Run();
        }
    }
}