using Customer_Order_Management_API.Models.Productions;

namespace Customer_Order_Management_API.IRepository.Productions
{
    public interface IStocksRepository
    {
        Task<IEnumerable<Stocks>> GetById(int? id1, int? id2);
        Task AddOrUpdateItemAsync(Stocks item);
        Task DeleteAsync(int id1, int id2);
    }
}
