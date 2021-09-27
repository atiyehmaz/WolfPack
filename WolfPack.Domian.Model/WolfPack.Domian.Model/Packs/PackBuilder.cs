using System;
using System.Collections.Generic;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Packs
{
    public class PackBuilder : IPackBuilder
    {
        private Guid? Id { get; set; }
        private string Name { get; set; }
        private DateTime CreationDate { get; set; }
        private DateTime ModificationDate { get; set; }
        private HashSet<Guid> Wolves { get; set; }

        public PackBuilder()
        {
            Wolves = new HashSet<Guid>();
        }
        public IPackBuilder WithId(Guid? id)
        {
            Id = id;
            return this;
        }

        public IPackBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IPackBuilder WithCreationDate(DateTime creationdate)
        {
            CreationDate = creationdate;
            return this;
        }

        public IPackBuilder WithModificationDate(DateTime modificationdate)
        {
            ModificationDate = modificationdate;
            return this;
        }

        public IPackBuilder WithWolf(Guid wolf)
        {
            Wolves.Add(wolf);
            return this;
        }

        public IPackBuilder WithWolves(ISet<Guid> wolves)
        {
            if (wolves == null)
                this.Wolves = null;
            else
            {
                foreach (var wolf in wolves)
                    this.Wolves.Add(wolf);
            }

            return this;
        }

        public Pack Build()
        {
            return new Pack(Name, Wolves);
        }

        public Pack BuildForDeserialization()
        {
            if (Id != null)
                return new Pack(Id.Value,
                    Name,
                    CreationDate,
                    ModificationDate,
                    Wolves);

            return null;
        }
    }
}