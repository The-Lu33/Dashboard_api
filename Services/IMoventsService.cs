using Dashboard_api.Models;
namespace Dashboard_api.Services
{
    public interface IMovementsService
    {
        Task<IEnumerable<Movements>> GetAllAsync();
        Task<IEnumerable<Movements>> GetAllAsyncForEmail(string email);
        Task CreateAsync(Movements move);
        Task UpdateAsync(string Email, Movements move);
        Task DeleteAsync(string Email);

    }
}