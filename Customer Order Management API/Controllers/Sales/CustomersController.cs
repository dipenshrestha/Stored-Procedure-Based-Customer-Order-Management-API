using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _repository;
        public CustomersController(ICustomersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id", Name = "GetCustomersById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Customers>>> GetCustomerById(int id)
        {
            try
            {
                List<Customers> obj = (List<Customers>) await _repository.GetById(id);
                if (obj.IsNullOrEmpty<Customers>())
                {
                    return NotFound("Customer Id not Found");
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
        public async Task<ActionResult<Customers>> CreateOrUpdateCustomers([FromBody] Customers Customers)
        {
            if (Customers == null || Customers.customer_id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(Customers);
                return Ok(Customers);
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
