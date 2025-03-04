using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;

namespace Customer_Order_Management_API.IRepository.Productions
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetById(int id);
        Task AddOrUpdateItemAsync(Categories item);
        Task DeleteAsync(int id);
    }
}
