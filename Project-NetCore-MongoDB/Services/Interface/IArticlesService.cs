using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Services.Interface
{
    public interface IArticlesService
    {
        Task<List<Articles>> GetAllAsync();
        Task<Articles> GetByIdAsync(string id);
        Task<Articles> CreateAsync(ArticlesDto articles);
        Task UpdateAsync(string id, ArticlesDto articles);
        Task DeleteAsync(string id);
    }
}
