using System;

namespace WolfPack.Domian.Model.Shared.Common
{
    public class AggregateRootBase : IAggregateRootBase
    {
        public Guid Id { get; protected set; }

        protected AggregateRootBase()
        {
            Id = Guid.NewGuid();
        }
    }
}