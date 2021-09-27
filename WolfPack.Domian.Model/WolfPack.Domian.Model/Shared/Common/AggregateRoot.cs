using System.Collections.Generic;

namespace WolfPack.Domian.Model.Shared.Common
{
    public class AggregateRoot : AggregateRootBase
    {
        public List<IDomainEvent> Events;

        protected void Raise(IDomainEvent domainEvent)
        {
            Events ??= new List<IDomainEvent>();
            this.Events.Add(domainEvent);
        }

        public void ClearEvents()
        {
            Events?.Clear();
        }
        
    }
}