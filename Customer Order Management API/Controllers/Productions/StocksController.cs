using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Productions
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStocksRepository _repository;

        public StocksController(IStocksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id", Name = "GetStocksById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Stocks>>> GetStocksById(int StoreId, int ProductId)
        {
            try
            {
                List<Stocks> obj = (List<Stocks>)await _repository.GetById(StoreId,ProductId);
                if (obj.IsNullOrEmpty<Stocks>())
                {
                    return NotFound("Store Id with Product Id not Found");
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Stocks>> CreateOrUpdateCustomers([FromBody] Stocks Stocks)
        {
            if (Stocks == null || (Stocks.Store_Id < 0 && Stocks.Product_Id < 0))
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(Stocks);
                return Ok(Stocks);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int StoreId, int ProductId)
        {
            if (StoreId == 0 && ProductId == 0)
            {
                return BadRequest();
            }

            await _repository.DeleteAsync(StoreId,ProductId);
            return NoContent();
        }
    }
}
