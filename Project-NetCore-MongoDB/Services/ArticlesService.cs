using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Services.Interface;
using AutoMapper;

namespace Project_NetCore_MongoDB.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IMapper _mapper;

        public ArticlesService(IArticlesRepository articlesRepository, IMapper mapper)
        {
            _articlesRepository = articlesRepository;
            _mapper = mapper;
        }

        public Task<List<Articles>> GetAllAsync()
        {
            return _articlesRepository.GetAllAsync();
        }

        public Task<Articles> GetByIdAsync(string id)
        {
            return _articlesRepository.GetByIdAsync(id);
        }

        public Task<Articles> CreateAsync(ArticlesDto articles)
        {
            var dataMapper = _mapper.Map<Articles>(articles);

            return _articlesRepository.CreateAsync(dataMapper);
            
        }

        public Task UpdateAsync(string id, ArticlesDto articles)
        {
            var dataMapper = _mapper.Map<Articles>(articles);
            
            return _articlesRepository.UpdateAsync(id, dataMapper);
        }

        public Task DeleteAsync(string id)
        {
            return _articlesRepository.DeleteAsync(id);
        }
    }
}
