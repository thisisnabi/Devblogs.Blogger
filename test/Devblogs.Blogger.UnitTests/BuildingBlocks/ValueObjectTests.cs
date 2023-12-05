namespace Devblogs.Blogger.UnitTests.BuildingBlocks;

public class ValueObjectTests
{
    [Fact]
    public void WithSameValuesAreEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(1);

        // Act & Assert
        valueObject1.Should().Be(valueObject2);
        (valueObject1 == valueObject2).Should().BeTrue();

    }

    [Fact]
    public void WithDifferentValuesAreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(2);

        // Act & Assert
        valueObject1.Should().NotBe(valueObject2);
        (valueObject1 != valueObject2).Should().BeTrue();
    }

    [Fact]
    public void WithSameValuesHaveSameHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(1);

        // Act & Assert
        valueObject1.GetHashCode().Should().Be(valueObject2.GetHashCode());
    }

    [Fact]
    public void WithDifferentValuesHaveDifferentHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(2);

        // Act & Assert
        valueObject1.GetHashCode().Should().NotBe(valueObject2.GetHashCode());
    }

    [Fact]
    public void WithDifferentValuesHaveDifferentHashCode1()
    {
        // Arrange
        TestValueObject valueObject1 = null;
        TestValueObject valueObject2 = null;

        // Act & Assert
        (valueObject1 == valueObject2).Should().BeTrue();
    }


}




public class TestValueObject : ValueObject
{
    public int Value { get; }

    public TestValueObject(int value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
