using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Project_NetCore_MongoDB.Dto
{
    public class UsersDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("phoneNumber")]
        public string? Phone { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        //[BsonRepresentation(BsonType.String)]
        //[BsonElement("role")]
        //public Role RolesName { get; set; }

        ////public enum Gender
        ////{
        ////    Male,
        ////    Female
        ////}

        //public enum Role
        //{
        //  User,
        //  Admin
        //}
    }
}
