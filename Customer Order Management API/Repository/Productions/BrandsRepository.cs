using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Productions
{
    public class BrandsRepository: IBrandsRepository
    {
        private readonly DapperContext _context;

        public BrandsRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task AddOrUpdateItemAsync(Brands item)
        {
            using var connection = _context.CreateConnection();
            if (item.Brand_Id == 0 || item.Brand_Id == null)
            {
                item.Brand_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("brand_id", item.Brand_Id);
            parameters.Add("brand_name", item.Brand_Name);
            var result = await connection.ExecuteAsync("inupBrands", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("brand_id", id);
            await connection.ExecuteAsync("deleteBrands", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Brands>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = $"SELECT * FROM fn_getBrands(@id)";
            var result = await connection.QueryAsync<Brands>(sql, new {id});
            return result;
        }
    }
}
