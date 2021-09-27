using WolfPack.Domian.Model.Packs;
using WolfPack.Infrastructure.MongoDbRepository.BsonModels;

namespace WolfPack.Infrastructure.MongoDbRepository.Packs
{
    public static class PackExtensions
    {
        public static BsonPack ToBsonPack(this Pack pack)
        {
            return new BsonPack
            {
                PackId = pack.Id,
                Name = pack.Name,
                CreationDate = pack.CreationDate,
                ModificationDate = pack.ModificationDate,
                Wolves = pack.Wolves,
            };
        }
    }
}