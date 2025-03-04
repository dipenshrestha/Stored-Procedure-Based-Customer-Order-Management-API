using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Productions
{
    public class CategoriesRepository:ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categories>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getCategories(@id)";
            var result = await connection.QueryAsync<Categories>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Categories item)
        {
            using var connection = _context.CreateConnection();
            if (item.Category_Id == 0 || item.Category_Id == null)
            {
                item.Category_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("category_id", item.Category_Id);
            parameters.Add("category_name", item.Category_Name);
            var result = await connection.ExecuteAsync("inupCategories", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("category_id", id);
            await connection.ExecuteAsync("deleteCategories", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
