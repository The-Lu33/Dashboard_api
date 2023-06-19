using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Dashboard_api.Models
{
    public class Movements
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int? Mont { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Email { get; set; }
    }
}