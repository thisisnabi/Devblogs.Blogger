namespace Devblogs.Blogger.Domain.BuildingBlocks;

public interface IAggregateRoot
{
    IReadOnlyCollection<DomainEventBase> Events { get; }

    void ClearEvents();
}
