using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepositroy _repository;

        public OrdersController(IOrdersRepositroy repositroy)
        {
            _repository = repositroy;
        }

        [HttpGet("id", Name = "GetOrdersById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Orders>>> GetOrdersById(int id)
        {
            try
            {
                List<Orders> obj = (List<Orders>)await _repository.GetById(id);
                if (obj.IsNullOrEmpty<Orders>())
                {
                    return NotFound("Orders Id not Found");
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
        public async Task<ActionResult<Orders>> CreateOrUpdateOrders([FromBody] Orders Orders)
        {
            if (Orders == null || Orders.Order_Id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(Orders);
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }

    }
}
