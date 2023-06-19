using Dashboard_api.Models;

namespace Dashboard_api.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetById(string id);
        Task CreateAsyncCategory(Category category);
        Task UpdateAsync(string id, Category category);
        Task DeleteAsync(string id);
    }
}