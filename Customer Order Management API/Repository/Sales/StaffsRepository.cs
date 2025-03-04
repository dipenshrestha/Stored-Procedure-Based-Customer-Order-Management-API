using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Sales
{
    public class StaffsRepository: IStaffsRepository
    {
        private readonly DapperContext _context;

        public StaffsRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staffs>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getStaffs(@id)";
            var result = await connection.QueryAsync<Staffs>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Staffs item)
        {
            using var connection = _context.CreateConnection();
            if(item.Staff_Id == 0 || item.Staff_Id == null)
            {
                item.Staff_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("staff_id", item.Staff_Id);
            parameters.Add("first_name", item.First_Name);
            parameters.Add("last_name", item.Last_Name);
            parameters.Add("email", item.Email);
            parameters.Add("phone", item.Phone);
            parameters.Add("store_id", item.Store_Id);
            var result = await connection.ExecuteAsync("inupStaffs", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("staff_id", id);
            await connection.ExecuteAsync("deleteStaffs", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
