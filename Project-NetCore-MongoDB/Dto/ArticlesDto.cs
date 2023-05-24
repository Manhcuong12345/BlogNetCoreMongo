using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Dto
{
    public class ArticlesDto
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("body")]
        public string? Body { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("authorId")]
        public string? AuthorId { get; set; }

        //[BsonElement("author")]
        //public Users Users { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("categoryId")]
        public string? CategoryId { get; set; }

        //[BsonElement("category")]
        //public Categories Categories { get; set; }

    }


}
