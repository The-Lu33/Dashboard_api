using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Dashboard_api.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }


    }
} 