using System;
using WolfPack.Domian.Model.Shared.Exceptions;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Wolves
{
    public partial class Wolf
    {
        public Wolf(Guid id, string code, DateTime creationDate,
            DateTime modificationDate,
            PersonalInformation personalInformation,
            Location location)
        {
            Id = id;
            Code = code;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            PersonalInformation = personalInformation;
            Location = location;

            
        }
    }
}