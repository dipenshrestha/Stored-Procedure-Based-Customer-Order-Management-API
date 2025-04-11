using Customer_Order_Management_API.IRepository;
using Customer_Order_Management_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Order_Management_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate(Users userdata)
        {
            var token = _jWTManager.Authenticate(userdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }

}
