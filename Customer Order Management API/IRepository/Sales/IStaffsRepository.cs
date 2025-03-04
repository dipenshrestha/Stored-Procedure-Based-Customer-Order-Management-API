using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;

namespace Customer_Order_Management_API.IRepository.Sales
{
    public interface IStaffsRepository
    {
        Task<IEnumerable<Staffs>> GetById(int id);
        Task AddOrUpdateItemAsync(Staffs item);
        Task DeleteAsync(int id);
    }
}
