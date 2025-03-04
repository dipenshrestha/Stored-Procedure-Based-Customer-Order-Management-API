using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Sales
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly DapperContext _context;

        public OrderItemsRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task AddOrUpdateItemAsync(OrderItems item)
        {
            using var connection = _context.CreateConnection();
            
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("order_id", item.order_id);
            parameters.Add("item_id", item.item_id);
            parameters.Add("product_id", item.product_id);
            parameters.Add("quantity", item.Quantity);
            parameters.Add("list_price", item.List_Price);
            parameters.Add("discount", item.Discount);
            var result = await connection.ExecuteAsync("inupOrderItems", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("item_id", id);
            await connection.ExecuteAsync("deleteOrderItems", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderItems>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getOrderItems(@id)";
            var result = await connection.QueryAsync<OrderItems>(sql, new { id = id });
            return result;
        }
    }
}
