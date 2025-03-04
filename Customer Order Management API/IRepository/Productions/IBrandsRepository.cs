using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;

namespace Customer_Order_Management_API.IRepository.Productions
{
    public interface IBrandsRepository
    {
        Task<IEnumerable<Brands>> GetById(int id);
        Task AddOrUpdateItemAsync(Brands item);
        Task DeleteAsync(int id);
    }
}
