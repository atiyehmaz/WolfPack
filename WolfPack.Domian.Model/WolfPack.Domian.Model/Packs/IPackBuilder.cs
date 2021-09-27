using System;
using System.Collections.Generic;

namespace WolfPack.Domian.Model.Packs
{
    public interface IPackBuilder
    {
        IPackBuilder WithId(Guid? id);
        IPackBuilder WithName(string name);
        IPackBuilder WithCreationDate(DateTime creationdate);
        IPackBuilder WithModificationDate(DateTime modificationdate);
        IPackBuilder WithWolves(ISet<Guid> wolves);
        IPackBuilder WithWolf(Guid wolf);

       
        Pack Build();
        Pack BuildForDeserialization();
    }
}