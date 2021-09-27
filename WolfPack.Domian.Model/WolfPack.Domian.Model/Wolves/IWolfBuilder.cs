using System;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Wolves
{
    public interface IWolfBuilder
    {
        IWolfBuilder WithId(Guid? id);
        IWolfBuilder WithCode(string code);
        IWolfBuilder WithCreationDate(DateTime creationdate);
        IWolfBuilder WithModificationDate(DateTime modificationdate);

        IWolfBuilder WithPersonalInformation(PersonalInformation personalInformation);
        IWolfBuilder WithLocation(Location location);
       
        //IWolfBuilder WithWolfService(WolfService wolfService);
        Wolf Build();
        Wolf BuildForDeserialization();
    }
}