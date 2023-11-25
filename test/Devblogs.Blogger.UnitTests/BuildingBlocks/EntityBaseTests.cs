namespace Devblogs.Blogger.UnitTests.BuildingBlocks;

public class EntityBaseTests
{

    [Fact]
    public void entities_of_different_type_should_not_be_equal()
    {
        var id = Guid.NewGuid();
        var student = new Car(id);
        var course = new Phone(id);

        (student == course).Should().BeFalse();
        course.Equals(student).Should().BeFalse();
        student.Equals(course).Should().BeFalse();

        (student.GetHashCode() == course.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void entities_of_same_type_should_be_equal_when_ids_match()
    {
        var id = Guid.NewGuid();
        var entityA = new Car(id);
        var entityB = new Car(id);

        (entityA == entityB).Should().BeTrue();
        entityA.Equals(entityB).Should().BeTrue();
        entityB.Equals(entityA).Should().BeTrue();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void entities_of_same_type_should_not_be_equal_when_ids_different()
    {
        var entityA = new Car(Guid.NewGuid());
        var entityB = new Car(Guid.NewGuid());

        (entityA == entityB).Should().BeFalse();
        entityA.Equals(entityB).Should().BeFalse();
        entityB.Equals(entityA).Should().BeFalse();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeFalse();
    }

}

public class Car : EntityBase<Guid>
{
    public Car(Guid id)
    {
        Id = id;
    }
}

public class Phone : EntityBase<Guid>
{
    public Phone(Guid id)
    {
        Id = id;
    }
}