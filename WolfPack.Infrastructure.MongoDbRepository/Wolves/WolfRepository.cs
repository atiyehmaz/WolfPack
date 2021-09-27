using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Infrastructure.MongoDbRepository.BsonModels;

namespace WolfPack.Infrastructure.MongoDbRepository.Wolves
{
    public class WolfRepository : IWolfRepository
    {
        private readonly IWolfFactory _wolfFactory;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase db;

        public WolfRepository(IMongoClient mongoClient, IWolfFactory wolfFactory)
        {
            _wolfFactory = wolfFactory;
            _mongoClient = mongoClient;
            db = _mongoClient.GetDatabase("WolfPack");
        }

        // public void TruncateWolfCollection()
        // {
        //     db.DropCollection("Wolf");
        // }
        
        public void Add(Wolf wolf)
        {
            var bsonWolf = wolf.ToBsonWolf();
        
            InsertRecord("Wolf", bsonWolf);
        }
        

        public void Delete(Wolf wolf)
        {
            var collections = db.GetCollection<BsonWolf>("Wolf");

            collections.DeleteOne(w => w.WolfId == wolf.Id);
        }

        public void Update(Wolf wolf)
        {
            var oldWolf = Get(wolf.Id);

            Delete(oldWolf);

            Add(wolf);
        }

        private void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.InsertOne(record);
        }

        public Wolf Get(Guid id)
        {
            var collections = db.GetCollection<BsonWolf>("Wolf");

            var bsonWolf = collections.Find(w => w.WolfId == id).FirstOrDefault();

            return ToWolf(bsonWolf);
        }

        public IEnumerable<Wolf> GetByCode(string code)
        {
            var collections = db.GetCollection<BsonWolf>("Wolf");

            var bsonWolves = collections.Find(w => w.Code == code).ToList();

            return ToWolves(bsonWolves);
        }

        public ISet<Wolf> GetAll()
        {
            var collections = db.GetCollection<BsonWolf>("Wolf");

            var bsonWolves = collections.Find(_=>true).ToList();

            return ToWolves(bsonWolves).ToHashSet();
        }

        private Wolf ToWolf(BsonWolf bsonWolf)
        {
            if (bsonWolf == null)
                return default;
                
            var wolf = _wolfFactory
                .WithNewWolfBuilder()
                .WithId(bsonWolf.WolfId)
                .WithCode(bsonWolf.Code)
                .WithCreationDate(bsonWolf.CreationDate)
                .WithModificationDate(bsonWolf.ModificationDate)
                .WithPersonalInformation(bsonWolf.PersonalInformation?.ToPersonalInformation())
                .WithLocation(bsonWolf.Location?.ToLocation())
                .BuildForDeserialization();

            return wolf;
        }

        private IEnumerable<Wolf> ToWolves(List<BsonWolf> bsonWolves)
        {
            var wolves = new List<Wolf>();

            foreach (var bsonWolf in bsonWolves)
            {
                wolves.Add(ToWolf(bsonWolf));
            }

            return wolves;
        }
    }
}