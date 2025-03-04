using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;

namespace Customer_Order_Management_API.IRepository.Sales
{
    public interface IOrdersRepositroy
    {
        Task<IEnumerable<Orders>> GetById(int id);
        Task AddOrUpdateItemAsync(Orders item);
        Task DeleteAsync(int id);
    }
}
