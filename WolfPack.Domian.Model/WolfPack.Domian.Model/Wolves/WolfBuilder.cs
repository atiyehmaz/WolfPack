using System;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Wolves
{
    public class WolfBuilder : IWolfBuilder
    {
        private Guid? Id { get; set; }
        private string Code { get; set; }
        private DateTime CreationDate { get; set; }
        private DateTime ModificationDate { get; set; }
        private PersonalInformation PersonalInformation { get; set; }
        private Location Location { get; set; }

        public IWolfBuilder WithId(Guid? id)
        {
            this.Id = id;
            return this;
        }

        public IWolfBuilder WithCode(string code)
        {
            this.Code = code;
            return this;
        }

        public IWolfBuilder WithCreationDate(DateTime creationdate)
        {
            this.CreationDate = creationdate;
            return this;
        }

        public IWolfBuilder WithModificationDate(DateTime modificationdate)
        {
            this.ModificationDate = modificationdate;
            return this;
        }

        public IWolfBuilder WithPersonalInformation(PersonalInformation personalInformation)
        {
            this.PersonalInformation = personalInformation;
            return this;
        }

        public IWolfBuilder WithLocation(Location location)
        {
            this.Location = location;
            return this;
        }

        public Wolf Build()
        {
            return new Wolf(Code, PersonalInformation, Location);
        }

        public Wolf BuildForDeserialization()
        {
            if (Id != null)
                return new Wolf(Id.Value,
                    Code,
                    CreationDate,
                    ModificationDate,
                    PersonalInformation,
                    Location);
                    
            return null;
        }
    }
}