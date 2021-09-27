using System;
using MediatR;

namespace WolfPack.Domian.Model.Shared.Common
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}