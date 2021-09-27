using System;
using System.Collections.Generic;
using WolfPack.Application.Packs.Commands;
using WolfPack.Domian.Model.Packs;

namespace WolfPack.Application.Packs
{
    public interface IPackApplicationService
    {
        void Create(CreatePackCommand createPackCommand);
        public void Remove(Guid id);
        Pack Get(Guid id);
        Pack GetByName(string name);
        ISet<Pack> GetAll();
         void AddWolfToPack(AddWolfToPackCommand addWolfToPackCommand);
         void Edit(EditPackCommand packCommand);
    }
}