using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;

namespace Project_NetCore_MongoDB.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IMongoCollection<Categories> _collection;
        private readonly DbConfiguration _settings;
        public CategoriesRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Categories>("categorie");
        }

        public Task<List<Categories>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Categories> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Categories> CreateAsync(Categories categories)
        {
            await _collection.InsertOneAsync(categories).ConfigureAwait(false);
            return categories;
        }
        public Task UpdateAsync(string id, Categories categories)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, categories);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
