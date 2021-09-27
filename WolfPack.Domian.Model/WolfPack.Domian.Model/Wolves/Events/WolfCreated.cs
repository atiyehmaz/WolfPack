using System;
using WolfPack.Domian.Model.Shared.Common;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Wolves.Events
{
    public class WolfCreated : DomainEvent
    {
        public Guid Id { get; protected set; }
        public string Code { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }

        public PersonalInformation PersonalInformation { get; private set; }

        public Location Location { get; private set; }

        public WolfCreated(Guid id, string code, DateTime creationDate,
            DateTime modificationDate, PersonalInformation personalInformation,
            Location location)
        {
            Id = id;
            Code = code;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            PersonalInformation=personalInformation;
            Location=location;
        }
    }
}