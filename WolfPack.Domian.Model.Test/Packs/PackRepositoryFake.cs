using System;
using System.Collections.Generic;
using System.Linq;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Domian.Model.Test.Packs
{
    public class PackRepositoryFake: IPackRepository
    {
        private readonly List<Pack> _packList;

        public PackRepositoryFake()
        {
            _packList = new List<Pack>();
        }
        
        public void Add(Pack wolf)
        {
            _packList.Add(wolf);
        }
        
        public void Delete(Pack pack)
        {
            var sourcePack = _packList.SingleOrDefault(p => p.Equals(pack));

            _packList.Remove(sourcePack);

        }

        public void Update(Pack pack)
        {
            var sourcePack = _packList.Single(p => p.Equals(pack));
            _packList.Remove(sourcePack);
            _packList.Add(pack);
        }

        public Pack Get(Guid id)
        {
            var pack = _packList.SingleOrDefault(x => x.Id == id);

            return pack;
        }

        public IEnumerable<Pack> GetByName(string name)
        {
            return _packList.Where(x => x.Name == name).ToList();
        }

        public ISet<Pack> GetAll()
        {
            return _packList.ToHashSet();

        }
    }
}