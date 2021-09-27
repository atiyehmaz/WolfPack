using System;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;
using WolfPack.Infrastructure.MongoDbRepository.BsonModels;

namespace WolfPack.Infrastructure.MongoDbRepository.Wolves
{
    public static class WolfExtensions
    {
        public static BsonWolf ToBsonWolf(this Wolf wolf)
        {
            var bsonWolf = new BsonWolf
            {
                WolfId = wolf.Id,
                Code = wolf.Code,
                CreationDate = wolf.CreationDate,
                ModificationDate = wolf.ModificationDate,
                PersonalInformation = wolf.PersonalInformation.ToBsonPersonalInformation(),
                Location = wolf.Location.ToBsonLocation()
            };

            return bsonWolf;
        }

        private static BsonPersonalInformation ToBsonPersonalInformation(this PersonalInformation personalInformation)
        {
            var bsonPersonalInformation = new BsonPersonalInformation
            {
                Name = personalInformation.Name,
                GenderType = personalInformation.GenderType,
                BirthDate = TimeZoneInfo.ConvertTimeToUtc(personalInformation.BirthDate),
            };

            return bsonPersonalInformation;
        }

        public static PersonalInformation ToPersonalInformation(this BsonPersonalInformation bsonPersonalInformation)
        {
            var personalInformation = new PersonalInformation(bsonPersonalInformation.Name,
                bsonPersonalInformation.GenderType,
                bsonPersonalInformation.BirthDate);

            return personalInformation;
        }

        private static BsonLocation ToBsonLocation(this Location location)
        {
            var bsonLocation = new BsonLocation
            {
                Longitude = location.Longitude,
                Latitude = location.Latitude,
                Description = location.Description,
            };

            return bsonLocation;
        }

        public static Location ToLocation(this BsonLocation bsonLocation)
        {
            var location = new Location(bsonLocation.Latitude,
                bsonLocation.Longitude,
                bsonLocation.Description);

            return location;
        }
    }
}