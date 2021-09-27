using System;
using System.Collections.Generic;
using System.Linq;
using WolfPack.Application.Wolves.Commands;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Application.Wolves
{
    public class WolfApplicationService : IWolfApplicationService
    {
        private readonly IWolfRepository _wolfRepository;
        private readonly IWolfFactory _wolfFactory;

        public WolfApplicationService(IWolfFactory wolfFactory, IWolfRepository wolfRepository)
        {
            _wolfFactory = wolfFactory;
            _wolfRepository = wolfRepository;
        }

        public void Create(CreateWolfCommand createWolfCommand)
        {
            var wolf = _wolfFactory
                .WithNewWolfBuilder()
                .WithCode(createWolfCommand.Code)
                .WithPersonalInformation(createWolfCommand.PersonalInformation)
                .WithLocation(createWolfCommand.Location)
                .Build();

            _wolfRepository.Add(wolf);
        }

        public void Remove(Guid id)
        {
            var wolf = _wolfRepository.Get(id);

            if (wolf != null)
            {
                //wolf.Remove();
                _wolfRepository.Delete(wolf);
            }
        }

        public Wolf Get(Guid id)
        {
            return _wolfRepository.Get(id);
        }

        public Wolf GetByCode(string code)
        {
            return _wolfRepository.GetByCode(code).SingleOrDefault();
        }

        public ISet<Wolf> GetAll()
        {
            return _wolfRepository.GetAll();
        }
        
       
    }
}