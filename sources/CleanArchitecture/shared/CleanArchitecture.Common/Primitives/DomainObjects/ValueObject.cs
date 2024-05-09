namespace CleanArchitecture.Common.Primitives.DomainObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    public bool Equals(ValueObject? other)
        => other is not null && ValuesAreEqual(other);

    public override int GetHashCode()
        => GetAtomicValues().Aggregate(default(int), HashCode.Combine);

    private bool ValuesAreEqual(ValueObject? other)
    {
        if (other is null)
            return false;

        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}
