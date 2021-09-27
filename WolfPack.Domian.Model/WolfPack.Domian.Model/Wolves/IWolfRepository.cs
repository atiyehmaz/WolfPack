using System;
using System.Collections.Generic;

namespace WolfPack.Domian.Model.Wolves
{
    public interface IWolfRepository
    {
        void Add(Wolf wolf);
        void Delete(Wolf wolf);
        void Update(Wolf wolf);
        Wolf Get(Guid id);
        IEnumerable<Wolf> GetByCode(string code);
        ISet<Wolf> GetAll();
    }
}