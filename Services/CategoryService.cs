using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Dashboard_api.Models;
namespace Dashboard_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category>? _CategoryCollection;
        private readonly IOptions<DB> _db;
        public CategoryService(IOptions<DB> db)
        {
            // config de inyeccion de config de base de datos
            _db = db;
            var mongoCLient = new MongoClient(db.Value.ConnectionString);
            var mongoDatabase = mongoCLient.GetDatabase(db.Value.DatabaseName);
            _CategoryCollection = mongoDatabase.GetCollection<Category>(db.Value.CategoriesCollection);

        }
        public async Task<IEnumerable<Category>> GetAllAsync() => await _CategoryCollection.Find(_ => true).ToListAsync();

        public async Task<Category> GetById(string id) => await _CategoryCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsyncCategory
        (Category category) => await _CategoryCollection.InsertOneAsync(category);

        public async Task UpdateAsync(string id, Category category) => await _CategoryCollection.FindOneAndReplaceAsync(a => a.Id == id, category);

        public async Task DeleteAsync(string id) => await _CategoryCollection.DeleteOneAsync(a => a.Id == id);
    }
}