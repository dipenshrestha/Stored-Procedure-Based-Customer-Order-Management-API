using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Productions
{
    public class StocksRepository:IStocksRepository
    {
        private readonly DapperContext _context;

        public StocksRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Stocks>> GetById(int? id1, int? id2)
        {
            using var connection = _context.CreateConnection();
            if (id1 == 0 && id2 == 0)
            {
                id1 = null;
                id2 = null;
            }
            //using sql function
            var sql = $"SELECT * FROM fn_getStocks(@id1,@id2)";
            var result = await connection.QueryAsync<Stocks>(sql, new { id1 = id1, id2 = id2 });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Stocks item)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("store_id", item.Store_Id);
            parameters.Add("product_id", item.Product_Id);
            parameters.Add("quantity", item.Quantity);
            var result = await connection.ExecuteAsync("inupStocks", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id1, int id2)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("store_id", id1);
            parameters.Add("product_id", id2);
            await connection.ExecuteAsync("deleteStocks", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
