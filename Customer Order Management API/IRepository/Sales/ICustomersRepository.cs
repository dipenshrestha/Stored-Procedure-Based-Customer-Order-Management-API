using Customer_Order_Management_API.Models.sales;

namespace Customer_Order_Management_API.IRepository.Sales
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customers>> GetById(int id);
        Task AddOrUpdateItemAsync(Customers item);
        Task DeleteAsync(int id);
    }
}
