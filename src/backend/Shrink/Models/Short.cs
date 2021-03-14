using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shrink.Models
{
    public class Short
    {
        [BsonId]
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        public string Code { get; set; }
        
        public string Url { get; set; }
        
        [BsonIgnore]
        public string Error { get; set; }
    }
}