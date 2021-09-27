using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Infrastructure.MongoDbRepository.BsonModels;

namespace WolfPack.Infrastructure.MongoDbRepository.Packs
{
    public class PackRepository : IPackRepository
    {
        private readonly IPackFactory _packFactory;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase db;

        public PackRepository(IMongoClient mongoClient, IPackFactory packFactory)
        {
            _packFactory = packFactory;
            _mongoClient = mongoClient;
            db = _mongoClient.GetDatabase("WolfPack");
        }

        // public void TruncateWolfCollection()
        // {
        //     db.DropCollection("Wolf");
        // }
        
        public void Add(Pack pack)
        {
            var bsonPack = pack.ToBsonPack();
        
            InsertRecord("Pack", bsonPack);
        }

        public void Delete(Pack pack)
        {
           var collections = db.GetCollection<BsonPack>("Pack");

           collections.DeleteOne(p => p.PackId == pack.Id);
           
        }
        

        public void Update(Pack pack)
        {
            var oldPack = Get(pack.Id);

            Delete(oldPack);

            Add(pack);
            
        }

        private void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.InsertOne(record);
        }

        public Pack Get(Guid id)
        {
            var collections = db.GetCollection<BsonPack>("Pack");
            
            var bsonPack = collections.Find(p => p.PackId == id).FirstOrDefault();
            
            return ToPack(bsonPack);

        }

        public IEnumerable<Pack> GetByName(string name)
        {
            var collections = db.GetCollection<BsonPack>("Pack");
            
            var bsonPacks = collections.Find(p => p.Name == name).ToList();
            
            return ToPacks(bsonPacks);
        }


        public ISet<Pack> GetAll()
        {
            var collections = db.GetCollection<BsonPack>("Pack");
            
            var bsonPacks = collections.Find(_=>true).ToList();
            
            return ToPacks(bsonPacks).ToHashSet();

        }

        private Pack ToPack(BsonPack bsonPack)
        {
            if (bsonPack == null)
                return default;
                
            var pack = _packFactory
                .WithNewPackBuilder()
                .WithId(bsonPack.PackId)
                .WithName(bsonPack.Name)
                .WithCreationDate(bsonPack.CreationDate)
                .WithModificationDate(bsonPack.ModificationDate)
                .WithWolves(bsonPack.Wolves)
                .BuildForDeserialization();
            
            return pack;

        }

        private IEnumerable<Pack> ToPacks(List<BsonPack> bsonPacks)
        {
            var packs = new List<Pack>();
            
            foreach (var bsonPack in bsonPacks)
            {
                packs.Add(ToPack(bsonPack));
            }
            
            return packs;
        }
    }
}