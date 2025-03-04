using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;

namespace Customer_Order_Management_API.IRepository.Sales
{
    public interface IStoresRepository
    {
        Task<IEnumerable<Stores>> GetById(int id);
        Task AddOrUpdateItemAsync(Stores item);
        Task DeleteAsync(int id);
    }
}
