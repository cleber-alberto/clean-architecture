using CleanArchitecture.Common.Primitives.DomainObjects;

namespace CleanArchitecture.UnitTests.Common.Primitives.DomainObjects;

public class ValueObjectTests
{
    [Fact]
    public void Equals_WithEqualValueObjects_ReturnsTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("value1", 1);
        var valueObject2 = new TestValueObject("value1", 1);

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentValueObjects_ReturnsFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("value1", 1);
        var valueObject2 = new TestValueObject("value2", 2);

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_WithEqualValueObjects_ReturnsSameHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject("value1", 1);
        var valueObject2 = new TestValueObject("value1", 1);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void GetHashCode_WithDifferentValueObjects_ReturnsDifferentHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject("value1", 1);
        var valueObject2 = new TestValueObject("value2", 2);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().NotBe(hashCode2);
    }

    class TestValueObject : ValueObject
    {
        public string Value1 { get; }
        public int Value2 { get; }

        public TestValueObject(string value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value1;
            yield return Value2;
        }
    }
}
