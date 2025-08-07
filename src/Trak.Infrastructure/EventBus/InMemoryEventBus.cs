using System.Threading.Channels;
using Trak.Core.Interfaces;
using Valhalla.Lib.SharedKernel;

namespace Trak.Infrastructure.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly Channel<DomainEventBase> _channel = Channel.CreateUnbounded<DomainEventBase>();

        public ValueTask PublishAsync<TEvent>(TEvent @event, CancellationToken ct) where TEvent : DomainEventBase
        {
            return _channel.Writer.WriteAsync(@event, ct);
        }

        public ChannelReader<DomainEventBase> Reader => _channel.Reader;
    }
}