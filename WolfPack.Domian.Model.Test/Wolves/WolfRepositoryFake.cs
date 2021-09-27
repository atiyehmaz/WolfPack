using System;
using System.Collections.Generic;
using System.Linq;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Domian.Model.Test.Wolves
{
    public class WolfRepositoryFake: IWolfRepository
    {
        private readonly List<Wolf> _wolvesList;

        public WolfRepositoryFake()
        {
            _wolvesList = new List<Wolf>();
        }
        
        public void Add(Wolf wolf)
        {
            _wolvesList.Add(wolf);
        }
        
        public void Delete(Wolf wolf)
        {
            var sourceWolf = _wolvesList.SingleOrDefault(w => w.Equals(wolf));

            _wolvesList.Remove(sourceWolf);

        }
        

        public void Update(Wolf wolf)
        {
            throw new NotImplementedException();
        }

        public Wolf Get(Guid id)
        {
            var wolf = _wolvesList.SingleOrDefault(x => x.Id == id);

            return wolf;
        }

        public IEnumerable<Wolf> GetByCode(string code)
        {
            return _wolvesList.Where(x => x.Code == code).ToList();
        }

        public ISet<Wolf> GetAll()
        {
            return _wolvesList.ToHashSet();

        }
    }
}