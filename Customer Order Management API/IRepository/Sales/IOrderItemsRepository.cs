using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;

namespace Customer_Order_Management_API.IRepository.Sales
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItems>> GetById(int id);
        Task AddOrUpdateItemAsync(OrderItems item);
        Task DeleteAsync(int id);
    }
}
