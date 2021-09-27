using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Infrastructure.MongoDbRepository.BsonModels
{
    public class BsonWolf
    { 
        [BsonId]
        public ObjectId Id{get;set;}
        
        [BsonElement("wolf_Id")]
        public Guid WolfId { get;  set; }
        
        [BsonElement("code")]
        public string Code { get;  set; }
        
        [BsonElement("creation_date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreationDate { get; set; }
        
        [BsonElement("modification_date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ModificationDate { get; set; }
        
        [BsonElement("personal_information")]
        public BsonPersonalInformation PersonalInformation { get;  set; }
        
        [BsonElement("location")]
        public BsonLocation Location { get;  set; }

    }
}