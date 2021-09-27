using System;
using System.Collections.Generic;
using System.Linq;
using WolfPack.Application.Packs.Commands;
using WolfPack.Domian.Model.Packs;

namespace WolfPack.Application.Packs
{
    public class PackApplicationService : IPackApplicationService
    {
        private readonly IPackRepository _packRepository;
        private readonly IPackFactory _packFactory;

        public PackApplicationService(IPackFactory packFactory, IPackRepository packRepository)
        {
            _packFactory = packFactory;
            _packRepository = packRepository;
        }

        public void Create(CreatePackCommand createPackCommand)
        {
            var builder = _packFactory
                .WithNewPackBuilder().WithName(createPackCommand.Name);

            if (createPackCommand.Wolves != null)
            {
                foreach (var wolf in createPackCommand.Wolves)
                {
                    builder.WithWolf(wolf);
                }
            }

            _packRepository.Add(builder.Build());
        }
        
        public void Edit(EditPackCommand editPackCommand)
        {
            var pack = _packRepository.Get(editPackCommand.Id);

            pack.Edit(
                editPackCommand.Name,
                editPackCommand.Wolves);

            _packRepository.Update(pack);
        }

        public void Remove(Guid id)
        {
            var wolf = _packRepository.Get(id);

            if (wolf != null)
            {
                //wolf.Remove();
                _packRepository.Delete(wolf);
            }
        }

        public Pack Get(Guid id)
        {
            return _packRepository.Get(id);
        }

        public Pack GetByName(string name)
        {
            return _packRepository.GetByName(name).SingleOrDefault();
        }

        public ISet<Pack> GetAll()
        {
            return _packRepository.GetAll();
        }
        
        public void AddWolfToPack(AddWolfToPackCommand addWolfToPackCommand)
        {
            var pack = _packRepository.Get(addWolfToPackCommand.Id);

            pack.AddWolf(addWolfToPackCommand.Wolf);

            _packRepository.Update(pack);
        }

        // public void RemovePersonageFromGroup(RemovePersonageFromGroupCommand removePersonageFromGroupCommandDto)
        // {
        //     var personageGroup = personageGroupRepository.Get(removePersonageFromGroupCommandDto.Id);
        //
        //     personageGroup.RemovePersonage(
        //         removePersonageFromGroupCommandDto.Personage
        //     );
        //
        //     personageGroupRepository.Update(personageGroup);
        // }
    }
}