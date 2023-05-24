using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Project_NetCore_MongoDB.Dto
{
    public class CategoriesDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("slug")]
        public string? Slug { get; set; }
    }
}
