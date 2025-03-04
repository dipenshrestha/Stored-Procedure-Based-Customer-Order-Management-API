using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Models.sales;
using Customer_Order_Management_API.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Order_Management_API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : Controller
    {
        private readonly IStaffsRepository _repository;

        public StaffsController(IStaffsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id", Name = "GetStaffsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Staffs>>> GetStaffsById(int id)
        {
            try
            {
                List<Staffs> obj = (List<Staffs>)await _repository.GetById(id);
                if (obj.IsNullOrEmpty<Staffs>())
                {
                    return NotFound("Staffs Id not Found");
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
        public async Task<ActionResult<Staffs>> CreateOrUpdateStaffs([FromBody] Staffs Staffs)
        {
            if (Staffs == null || Staffs.Staff_Id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _repository.AddOrUpdateItemAsync(Staffs);
                return Ok(Staffs);
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
