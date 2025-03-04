using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.Models.Productions;
using Customer_Order_Management_API.Models.sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Productions
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsRepository _repository;

        public BrandsController(IBrandsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id", Name = "GetBrandsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Brands>>> GetCustomerById(int id)
        {
            try
            {
                List<Brands> obj = (List<Brands>)await _repository.GetById(id);
                if (obj.IsNullOrEmpty<Brands>())
                {
                    return NotFound("Brands Id not Found");
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
        public async Task<ActionResult<Brands>> CreateOrUpdateBrands([FromBody] Brands Brands)
        {
            if (Brands == null || Brands.Brand_Id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(Brands);
                return Ok(Brands);
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
