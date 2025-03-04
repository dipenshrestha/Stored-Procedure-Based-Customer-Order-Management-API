
using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsRepository _repository;

        public OrderItemsController(IOrderItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id", Name = "GetOrderItemsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<OrderItems>>> GetOrderItemsById(int id)
        {
            try
            {
                List<OrderItems> obj = (List<OrderItems>)await _repository.GetById(id);
                if (obj.IsNullOrEmpty<OrderItems>())
                {
                    return NotFound("OrderItems Id not Found");
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
        public async Task<ActionResult<OrderItems>> CreateOrUpdateCustomers([FromBody] OrderItems OrderItems)
        {
            if (OrderItems == null || OrderItems.item_id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(OrderItems);
                return Ok(OrderItems);
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
