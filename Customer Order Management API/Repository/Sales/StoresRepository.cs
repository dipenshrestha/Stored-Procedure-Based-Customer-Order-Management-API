using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Sales
{
    public class StoresRepository:IStoresRepository
    {
        private readonly DapperContext _context;

        public StoresRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Stores>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getStores(@id)";
            var result = await connection.QueryAsync<Stores>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Stores item)
        {
            using var connection = _context.CreateConnection();
            if (item.Store_Id == 0 || item.Store_Id == null)
            {
                item.Store_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("store_id", item.Store_Id);
            parameters.Add("store_name", item.Store_Name);
            parameters.Add("phone", item.Phone);
            parameters.Add("email", item.Email);
            parameters.Add("street", item.Street);
            parameters.Add("city", item.City);
            parameters.Add("state", item.State);
            parameters.Add("zip_code", item.Zip_Code);
            var result = await connection.ExecuteAsync("inupStores", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("store_id", id);
            await connection.ExecuteAsync("deleteStores", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
