using System;
using System.Collections.Generic;
using WolfPack.Domian.Model.Shared.Common;
using WolfPack.Domian.Model.Shared.Exceptions;

namespace WolfPack.Domian.Model.Packs
{
    public partial class Pack : AggregateRoot
    {
        public const int MaxNameLength = 50;

        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public ISet<Guid> Wolves { get; private set; }

        public Pack(string name, ISet<Guid> wolves)
        {
            Id = Guid.NewGuid();

            Set(name, wolves);
        }

        public void Edit(string name, ISet<Guid> wolves = null)
        {
            Set(name, wolves);
        }

        private void Set(string name, ISet<Guid> wolves = null)
        {
            DomainAssert.NotNullOrWhitespace(name, PackValidationMessage.NameNullOrWhiteSpace);
            DomainAssert.LengthNotGreaterThan(name, MaxNameLength, PackValidationMessage.GreaterThanMaxName);
            Name = name;

            CreationDate = DateTime.UtcNow.Truncate(TimeSpan.TicksPerSecond);
            ModificationDate = DateTime.UtcNow.Truncate(TimeSpan.TicksPerSecond);

            if (wolves != null)
            {
                Wolves = new HashSet<Guid>(wolves);
            }
        }
        // public  void Remove()
        // {
        //     
        // }

        public void AddWolf(Guid wolf)
        {
            if (Wolves.Contains(wolf))
                throw new DomainException(PackValidationMessage.DuplicatedWolf);
            Wolves.Add(wolf);
        }

        public void RemoveWolf(Guid wolf)
        {
            Wolves.Remove(wolf);
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetCreationDate(DateTime creationDate)
        {
            CreationDate = creationDate;
        }

        public void SetModificationDate(DateTime modificationDate)
        {
            ModificationDate = modificationDate;
        }

        public void SetWolves(ISet<Guid> wolves)
        {
            if (wolves != null)
            {
                Wolves = new HashSet<Guid>(wolves);
            }
        }
    }
}