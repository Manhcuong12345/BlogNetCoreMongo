using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetAllAsync();
        Task<Categories> GetByIdAsync(string id);
        Task<Categories> CreateAsync(Categories categories);
        Task UpdateAsync(string id, Categories categories);
        Task DeleteAsync(string id);
    }
}
