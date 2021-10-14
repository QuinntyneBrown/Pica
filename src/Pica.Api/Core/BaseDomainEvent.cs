using Pica.Api.Interfaces;
using System;

namespace Pica.Api.Core
{
    public class BaseDomainEvent : IEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public Guid CorrelationId { get; set; }

        public void WithCorrelationIdFrom(IEvent @event)
        {

        }
    }
}
