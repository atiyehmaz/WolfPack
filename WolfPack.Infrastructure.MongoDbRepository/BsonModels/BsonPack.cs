using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WolfPack.Infrastructure.MongoDbRepository.BsonModels
{
    public class BsonPack
    {
        [BsonId]
        public ObjectId Id{get;set;}
        
        [BsonElement("pack_Id")]
        public Guid PackId { get;  set; }
        
        [BsonElement("name")]
        public string Name { get;  set; }
        
        [BsonElement("wolves")]
        public ISet<Guid> Wolves { get;  set; }
        
        [BsonElement("creation_date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreationDate { get; set; }
        
        [BsonElement("modification_date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ModificationDate { get; set; }

    }
}