using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Sales
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customers>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getCustomers(@id)";
            var result = await connection.QueryAsync<Customers>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Customers item)
        {
            using var connection = _context.CreateConnection();
            if (item.customer_id == 0 || item.customer_id == null)
            {
                item.customer_id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("customer_id", item.customer_id);
            parameters.Add("first_name", item.first_name);
            parameters.Add("last_name", item.last_name);
            parameters.Add("phone", item.phone);
            parameters.Add("email", item.email);
            parameters.Add("street", item.street);
            parameters.Add("city", item.city);
            parameters.Add("state", item.state);
            var result = await connection.ExecuteAsync("inupCustomers", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("customer_id", id);
            await connection.ExecuteAsync("deleteCustomers", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
