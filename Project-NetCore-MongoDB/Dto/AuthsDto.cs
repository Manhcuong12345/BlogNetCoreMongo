using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Project_NetCore_MongoDB.Dto
{
    public class AuthsDto
    {
        
        [BsonElement("email")]
        public string? Email { get; set; }

        [Required]
        [BsonElement("password")]
        public string? Password { get; set; }
    }
}
