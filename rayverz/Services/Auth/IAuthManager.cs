using Maharat.Data.DTOs.Users;

namespace rayverz.Services.Auth
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(string email, string password);
        Task<string> CreateToken();
    }
}
