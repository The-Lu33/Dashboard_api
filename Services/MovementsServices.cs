using Dashboard_api.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Dashboard_api.Services
{
    public class MovementsService : IMovementsService
    {
        private readonly IMongoCollection<Movements>? _MovementsCollection;

        private readonly IOptions<DB> _db;

        public MovementsService(IOptions<DB> db)
        {
            _db = db;

            var MongoClient = new MongoClient(db.Value.ConnectionString);

            var mongoDatabase = MongoClient.GetDatabase(db.Value.DatabaseName);

            _MovementsCollection = mongoDatabase.GetCollection<Movements>(db.Value.MovementsCollection);
        }

        public async Task<IEnumerable<Movements>> GetAllAsync() => await _MovementsCollection.Find(_ => true).ToListAsync();
        // get por email 
        public async Task<IEnumerable<Movements>> GetAllAsyncForEmail(string email)
        {
            var filter = Builders<Movements>.Filter.Eq("Email", email);
            return await _MovementsCollection.Find(filter).ToListAsync();
        }
        public async Task CreateAsync(Movements move) => await _MovementsCollection.InsertOneAsync(move);

        public async Task UpdateAsync(string Email, Movements move) => await _MovementsCollection.FindOneAndReplaceAsync
        (a => a.Email == Email, move);

        public async Task DeleteAsync(string Email) => await _MovementsCollection.DeleteOneAsync(a => a.Email == Email);

    }
}