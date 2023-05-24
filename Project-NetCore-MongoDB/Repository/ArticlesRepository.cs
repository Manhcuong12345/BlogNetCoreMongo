using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;
using System.Security.Claims;

namespace Project_NetCore_MongoDB.Repository
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly IMongoCollection<Articles> _collection;
        private readonly DbConfiguration _settings;
        public ArticlesRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Articles>("articles");
        }

        public Task<List<Articles>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Articles> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Articles> CreateAsync(Articles articles)
        {
            await _collection.InsertOneAsync(articles).ConfigureAwait(false);
            return articles;
        }
        public Task UpdateAsync(string id, Articles articles)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, articles, new UpdateOptions { IsUpsert = true });
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
