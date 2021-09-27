using System;

namespace WolfPack.Domian.Model.Shared.Common
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            this.OccurredOn = DateTime.Now;
        }
    }
}