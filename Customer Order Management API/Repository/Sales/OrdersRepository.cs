using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Sales
{
    public class OrdersRepository:IOrdersRepositroy
    {
        private readonly DapperContext _context;

        public OrdersRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orders>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getOrders(@id)";
            var result = await connection.QueryAsync<Orders>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Orders item)
        {
            using var connection = _context.CreateConnection();
            if(item.Order_Id == null || item.Order_Id == 0)
            {
                item.Order_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("order_id", item.Order_Id);
            parameters.Add("customer_id", item.Customer_Id);
            parameters.Add("order_status", item.Order_Status);
            parameters.Add("order_date", item.Order_Date);
            parameters.Add("required_date", item.Required_Date);
            parameters.Add("shipped_date", item.Shipped_Date);
            parameters.Add("store_id", item.Store_Id);
            parameters.Add("staff_id", item.Staff_Id);
            var result = await connection.ExecuteAsync("inupOrders", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("order_id", id);
            await connection.ExecuteAsync("deleteOrders", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
