using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Infrastructure.MongoDbRepository.BsonModels
{
    public class BsonPersonalInformation
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("gender_type")]
        public GenderType GenderType { get; set; }
        
        [BsonElement("birth_date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime BirthDate { get; set; }
    }
}