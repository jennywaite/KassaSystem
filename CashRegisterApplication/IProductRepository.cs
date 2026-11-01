using CashRegisterApplication.Models;

public interface IProductRepository
{
    Product? FindById(int id);
    List<Product> GetAllProducts();
}