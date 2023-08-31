public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    // Purpose: Defines a base class for entities with unique identifiers.
    // Usage: Entities represent objects in your domain model that have distinct identities, often related to database records.

    public TId Id { get; protected set; }
    // This is a property named 'Id' of type 'TId' with a protected setter.
    // It's used to store the unique identifier of an entity.

    protected Entity(TId id)
    {
        // This is a constructor for the 'Entity' class.
        // It takes an 'id' of type 'TId' as a parameter and initializes the 'Id' property.

        Id = id;
    }
    protected Entity(){

    }

    public override bool Equals(object? obj)
    {
        // Purpose: Compares entities for equality based on their 'Id' property.
        // Usage: Ensures that entities with the same 'Id' are considered equal.

        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        // Purpose: Overloads the '==' operator to enable equality comparison of entities.
        // Usage: Allows comparing two entities for equality using the '==' operator based on their 'Id' values.

        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        // Purpose: Overloads the '!=' operator to enable inequality comparison of entities.
        // Usage: Allows comparing two entities for inequality using the '!=' operator based on their 'Id' values.

        return !Equals(left, right);
    }

    public bool Equals(Entity<TId>? other)
    {
        // Purpose: Provides an alternative implementation of the 'Equals' method.
        // Usage: Allows comparing an 'Entity' object with another 'Entity' object for equality based on their 'Id' values.

        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        // Purpose: Generates a hash code for an entity based on its 'Id' property.
        // Usage: Essential for efficient storage and retrieval of entities in hash-based data structures.

        return Id.GetHashCode();
    }
}
