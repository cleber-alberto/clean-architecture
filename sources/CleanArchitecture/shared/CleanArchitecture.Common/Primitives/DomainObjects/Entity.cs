namespace CleanArchitecture.Common.Primitives.DomainObjects;

public abstract class Entity : IEquatable<Entity>, ICloneable
{
    public Guid Id { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((Entity)obj);
    }

    public virtual bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);

    public override int GetHashCode() => Id.GetHashCode();

    public object Clone() => MemberwiseClone();

    public override string ToString() => $"{GetType().Name}({Id})";
}
