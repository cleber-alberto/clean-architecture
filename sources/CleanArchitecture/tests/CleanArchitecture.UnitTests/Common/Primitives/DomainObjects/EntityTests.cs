using System.Data.Common;
using CleanArchitecture.Common.Primitives.DomainObjects;

namespace CleanArchitecture.UnitTests.Common.Primitives.DomainObjects;

public class EntityTests
{
    [Fact]
    public void Entity_Equals_ReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Entity_Equals_ReturnsFalse()
    {
        // Arrange
        var entity1 = new TestEntity(Guid.NewGuid());
        var entity2 = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_Equals_ReturnsFalseForNull()
    {
        // Arrange
        var entity = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_Equals_ReturnsFalseForSameReference()
    {
        // Arrange
        var entity = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity.Equals(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Entity_Equals_ReturnsFalseForDifferentType()
    {
        // Arrange
        var entity = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity.Equals(new object());

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_Equals_ReturnsFalseForNullDifferentType()
    {
        // Arrange
        var entity = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity.Equals((object?)null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_Equals_ReturnsTrueForReferenceEqualsObject()
    {
        // Arrange
        var entity = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity.Equals((object)entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Entity_EqualsOperator_ReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Entity_EqualsOperator_ReturnsFalse()
    {
        // Arrange
        var entity1 = new TestEntity(Guid.NewGuid());
        var entity2 = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_NotEqualsOperator_ReturnsTrue()
    {
        // Arrange
        var entity1 = new TestEntity(Guid.NewGuid());
        var entity2 = new TestEntity(Guid.NewGuid());

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Entity_NotEqualsOperator_ReturnsFalse()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Entity_GetHashCode_ReturnsIdHashCode()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        // Act
        var result = entity.GetHashCode();

        // Assert
        result.Should().Be(id.GetHashCode());
    }

    [Fact]
    public void Entity_ToString_ReturnsTypeNameAndId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        // Act
        var result = entity.ToString();

        // Assert
        result.Should().Be($"{entity.GetType().Name}({id})");
    }

    [Fact]
    public void Entity_Clone_ReturnsSameEntity()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        // Act
        var result = entity.Clone();

        // Assert
        result.Should().Be(entity);
    }

    class TestEntity : Entity
    {
        public TestEntity(Guid id)
        {
            Id = id;
        }
    }

    record TestRecord(Guid Id);
}
