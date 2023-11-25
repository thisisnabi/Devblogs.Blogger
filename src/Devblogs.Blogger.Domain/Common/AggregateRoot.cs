using System.Collections.Immutable;
namespace Devblogs.Blogger.Domain.Common;

public abstract class AggregateRoot<TKey> : EntityBase<TKey>, IAggregateRoot
    where TKey : struct
{
    private readonly IList<DomainEventBase> _events;

    public IReadOnlyCollection<DomainEventBase> Events => _events.ToImmutableArray();

    protected void RegisterEvent(DomainEventBase domainEvent) => _events.Add(domainEvent);

    protected AggregateRoot()
    {
        _events = new List<DomainEventBase>();
    }

    public void ClearEvents() => _events.Clear();
}
