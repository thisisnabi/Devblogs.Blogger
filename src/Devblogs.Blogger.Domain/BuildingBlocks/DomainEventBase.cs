namespace Devblogs.Blogger.Domain.BuildingBlocks;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
