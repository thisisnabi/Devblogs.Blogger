namespace Devblogs.Blogger.UnitTests.BuildingBlocks;

public class DomainEventBaseTests
{
    [Fact]
    public void SetsDataOccurredToCurrentDateTime()
    {
        // Arrange
        var beforeCreation = DateTime.UtcNow;

        // Act 
        var domainEvent = new TestDomainEvent();

        // Assert
        domainEvent.DateOccurred.Should().BeOnOrAfter(beforeCreation);
        domainEvent.DateOccurred.Should().BeOnOrBefore(DateTime.UtcNow);
    }
}


public class TestDomainEvent : DomainEventBase { };