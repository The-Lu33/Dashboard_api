using Dashboard_api.Models;

namespace Dashboard_api.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<IEnumerable<Users>> LoginSingUp(Users user);

    }
}