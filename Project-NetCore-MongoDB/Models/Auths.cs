using MongoDB.Bson.Serialization.Attributes;

namespace Project_NetCore_MongoDB.Models
{
    public class abc
    {

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

       
    }
}
