namespace Devblogs.Blogger.Domain.Common;

public interface IAggregateRoot
{
    IReadOnlyCollection<DomainEventBase> Events { get; }

    void ClearEvents();
}
