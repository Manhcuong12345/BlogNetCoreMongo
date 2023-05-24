using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
//using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Models
{
    public class Users
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

        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonRepresentation(BsonType.String)]
        [BsonElement("role")]
        public Role RolesName { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        public enum Role
        {
           User,
           Admin
        }

        //public enum Gender
        //{
        //   Male,
        //    Female
        //}

    }
}
