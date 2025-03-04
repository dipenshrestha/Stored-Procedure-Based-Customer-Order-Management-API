using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;
using Dapper;
using DapperAPI.Models;
using System.Data;

namespace Customer_Order_Management_API.Repository.Productions
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly DapperContext _context;

        public ProductsRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            //using sql function
            var sql = $"SELECT * FROM fn_getProducts(@id)";
            var result = await connection.QueryAsync<Products>(sql, new { id = id });
            return result;
        }

        public async Task AddOrUpdateItemAsync(Products item)
        {
            using var connection = _context.CreateConnection();
            if (item.Product_Id == 0 || item.Product_Id == null)
            {
                item.Product_Id = null;
            }
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("product_id", item.Product_Id);
            parameters.Add("product_name", item.Product_Name);
            parameters.Add("brand_id", item.Brand_Id);
            parameters.Add("category_id", item.Category_Id);
            parameters.Add("model_year", item.Model_Year);
            parameters.Add("list_price", item.List_Price);
            var result = await connection.ExecuteAsync("inupProducts", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("product_id", id);
            await connection.ExecuteAsync("deleteProducts", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
