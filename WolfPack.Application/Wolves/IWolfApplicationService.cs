using System;
using System.Collections.Generic;
using WolfPack.Application.Wolves.Commands;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Application.Wolves
{
    public interface IWolfApplicationService
    {
        void Create(CreateWolfCommand createWolfCommand);
        public void Remove(Guid id);
        Wolf Get(Guid id);
        Wolf GetByCode(string code);
        ISet<Wolf> GetAll();
    }
}