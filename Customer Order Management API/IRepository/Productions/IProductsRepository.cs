using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;

namespace Customer_Order_Management_API.IRepository.Productions
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetById(int id);
        Task AddOrUpdateItemAsync(Products item);
        Task DeleteAsync(int id);
    }
}
