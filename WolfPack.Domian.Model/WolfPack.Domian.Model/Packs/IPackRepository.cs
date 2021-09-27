using System;
using System.Collections.Generic;

namespace WolfPack.Domian.Model.Packs
{
    public interface IPackRepository
    {
        void Add(Pack pack);
        void Delete(Pack pack);
        void Update(Pack pack);
        Pack Get(Guid id);
        IEnumerable<Pack> GetByName(string name);
        ISet<Pack> GetAll();
    }
}