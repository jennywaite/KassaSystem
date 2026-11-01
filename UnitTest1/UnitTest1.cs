using CashRegisterApplication.Models;
using CashRegisterApplication.Repositories;
using Xunit;

namespace CashRegisterApplication.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void SaleCalculatesCorrectTotal()
        {
            Product milk = new Product(102, "Milk", 15.90m, PriceType.Per);

            Sale sale = new Sale();
            sale.AddItem(milk, 2);

            decimal total = sale.GetTotal();

            Assert.Equal(31.80m, total);
        }

        [Fact]
        public void SaleRejectsNegativeQuantity()
        {
            Product milk = new Product(102, "Milk", 15.90m, PriceType.Per);

            Sale sale = new Sale();

            Assert.Throws<ArgumentException>(() => sale.AddItem(milk, -2));
        }

        [Fact]
        public void SaleRejectsDecimalQuantityForStyck()
        {
            Product milk = new Product(102, "Milk", 15.90m, PriceType.Per);

            Sale sale = new Sale();

            Assert.Throws<ArgumentException>(() => sale.AddItem(milk, 1.5m));
        }

        [Fact]
        public void ProductRepositoryLoadsProductsFromFile()
        {
            string filePath = Path.GetTempFileName();

            try
            {
                File.WriteAllText(filePath,
                    "101;Bananas;29.90;Kg\n" +
                    "102;Milk;15.90;Per\n" +
                    "103;Coffee;59.90;Per");

                ProductRepository repository = new ProductRepository();

                repository.LoadFromFile(filePath);

                Assert.Equal(3, repository.GetAllProducts().Count);
                Assert.Equal("Milk", repository.FindById(102)?.Name);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

    }
}