using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository;

namespace Project_NetCore_MongoDB.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categorieRepository;

        public CategoriesService(ICategoriesRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public Task<List<Categories>> GetAllAsync()
        {
            return _categorieRepository.GetAllAsync();
        }

        public Task<Categories> GetByIdAsync(string id)
        {
            return _categorieRepository.GetByIdAsync(id);
        }

        public Task<Categories> CreateAsync(Categories categories)
        {
            return _categorieRepository.CreateAsync(categories);
        }

        public Task UpdateAsync(string id, Categories categories)
        {
            return _categorieRepository.UpdateAsync(id, categories);
        }

        public Task DeleteAsync(string id)
        {
            return _categorieRepository.DeleteAsync(id);
        }
    }
}
