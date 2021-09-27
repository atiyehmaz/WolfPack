using MongoDB.Bson.Serialization.Attributes;

namespace WolfPack.Infrastructure.MongoDbRepository.BsonModels
{
    public class BsonLocation
    {
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        
        [BsonElement("longitude")]
        public double Longitude { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
    }
}