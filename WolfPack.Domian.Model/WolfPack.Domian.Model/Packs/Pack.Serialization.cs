using System;
using System.Collections.Generic;
using WolfPack.Domian.Model.Shared.Exceptions;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Packs
{
    public partial class Pack
    {
        public Pack(Guid id, string name,DateTime creationDate,
            DateTime modificationDate, ISet<Guid> wolves)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            Wolves= wolves;
        }
    }
}