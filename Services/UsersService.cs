using Dashboard_api.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Dashboard_api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<Users>? _UsersCollection;

        private readonly IOptions<DB>? _db;

        public UsersService(IOptions<DB> db)
        {
            _db = db;

            var MongoClient = new MongoClient(db.Value.ConnectionString);

            var mongoDatabase = MongoClient.GetDatabase(db.Value.DatabaseName);

            _UsersCollection = mongoDatabase.GetCollection<Users>(db.Value.UsersCollection
            );
        }
        public async Task<IEnumerable<Users>> GetAllAsync() => await _UsersCollection.Find(_UsersCollection => true).ToListAsync();

        public async Task<IEnumerable<Users>> LoginSingUp(Users user)
        {
            var login = await _UsersCollection.Find(u => u.Email == user.Email).FirstOrDefaultAsync();
            Console.WriteLine(login);

            if (login == null)
            {
                Console.WriteLine("No existe usuario");
                try
                {
                    await _UsersCollection!.InsertOneAsync(user);
                    Console.WriteLine("Usuario registrado correctamente");
                    return Enumerable.Empty<Users>(); // O devuelve otra colección de usuarios si es necesario
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al registrar el usuario: " + ex.Message);
                    // Manejar el error según tus necesidades
                    return null;
                }
            }
            else
            {
                Console.WriteLine(login);

                Console.WriteLine("login");

                return null;
            }
            return null;

        }


    }


}