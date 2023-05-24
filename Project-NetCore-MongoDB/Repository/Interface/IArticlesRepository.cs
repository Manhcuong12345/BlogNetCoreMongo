using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository.Interface
{
    public interface IArticlesRepository
    {
        Task<List<Articles>> GetAllAsync();
        Task<Articles> GetByIdAsync(string id);
        Task<Articles> CreateAsync(Articles articles);
        Task UpdateAsync(string id, Articles articles);
        Task DeleteAsync(string id);
    }
}
