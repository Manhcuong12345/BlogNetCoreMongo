using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Services
{
    public interface ICategoriesService
    {
        Task<List<Categories>> GetAllAsync();
        Task<Categories> GetByIdAsync(string id);
        Task<Categories> CreateAsync(Categories categories);
        Task UpdateAsync(string id, Categories categories);
        Task DeleteAsync(string id);
    }
}
