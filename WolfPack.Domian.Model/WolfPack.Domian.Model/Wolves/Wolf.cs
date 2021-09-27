using System;
using WolfPack.Domian.Model.Shared.Common;
using WolfPack.Domian.Model.Shared.Exceptions;
using WolfPack.Domian.Model.Wolves.Events;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Wolves
{
    public partial class Wolf : AggregateRoot
    {
        public const int MaxCodeLength = 20;

        public string Code { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public PersonalInformation PersonalInformation { get; private set; }
        public Location Location { get; private set; }

        //public WolfService WolfService { get; private set; }

        public Wolf(string code, PersonalInformation personalInformation, Location location)
        {
            Id = Guid.NewGuid();

            DomainAssert.NotNullOrWhitespace(code, WolfValidationMessage.CodeNullOrWhiteSpace);
            DomainAssert.LengthNotGreaterThan(code, MaxCodeLength, WolfValidationMessage.GreaterThanMaxCode);
            Code = code;

            CreationDate = DateTime.UtcNow.Truncate(TimeSpan.TicksPerSecond);
            ModificationDate = DateTime.UtcNow.Truncate(TimeSpan.TicksPerSecond);
            PersonalInformation = personalInformation;
            Location = location;

            Raise(new WolfCreated(
                Id,
                Code,
                CreationDate,
                ModificationDate,
                PersonalInformation,
                Location));
        }


        public void Edit(string code,
            PersonalInformation personalInformation,
            Location location)
        {
            Code = code;
            PersonalInformation = personalInformation;
            Location = location;
        }

        // public  void Remove()
        // {
        //     
        // }

        public void SetId(Guid id)
        {
            Id = id;
        }
        public void SetCode(string code)
        {
            Code = code;
        }
        public void SetCreationDate( DateTime creationDate)
        {
            CreationDate = creationDate;
        }
        
        public void SetModificationDate( DateTime modificationDate)
        {
            ModificationDate = modificationDate;
        }
        
        public void SetPersonalInformation(PersonalInformation personalInformation)
        {
            PersonalInformation = PersonalInformation;
        }
        public void SetLocation(Location location)
        {
            Location = location;
        }
        
    }
}