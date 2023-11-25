namespace Devblogs.Blogger.UnitTests.BuildingBlocks;

public class AggregateRootTests
{
    [Fact]
    public void AddsDomainEventToAggregateRoot()
    {
        // Arrange
        var Id = Random.Shared.Next(int.MaxValue);
        var entity = new User(Id);

        // Act
        entity.AddProfileUpdatedEvent();

        // Assert
        entity.Events.Should().HaveCount(1);
        entity.Events.Should().AllBeOfType<ProfileUpdatedEvent>();
    }
}


public class ProfileUpdatedEvent : DomainEventBase { }

public class User : AggregateRoot<long>
{
    public User(int id)
    {
        Id = id;
    }

    public void AddProfileUpdatedEvent()
    {
        var domainEvent = new ProfileUpdatedEvent();
        RegisterEvent(domainEvent);
    }
}