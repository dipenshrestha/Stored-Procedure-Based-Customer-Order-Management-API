using Customer_Order_Management_API.Models;

namespace Customer_Order_Management_API.IRepository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
        string GenerateRefreshToken();
    }
}
