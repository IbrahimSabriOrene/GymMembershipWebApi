namespace Customer.Domain.Models;
// This is a namespace declaration, which organizes your code into a specific scope.

// Value object considered equal if all properties are same
// PackageName, Price, Months are value objects
public abstract class ValueObject : IEquatable<ValueObject>
{
    // Purpose: Defines a base class for value objects, which are objects considered equal if all their properties are the same.
    // Usage: Value objects are often used to represent properties of entities without their own identity, like the 'Price' class below.

    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        if (GetType() != obj.GetType())
            return false;

        var valueObject = (ValueObject)obj;

        // Purpose: Compares two value objects for equality based on their equality components.
        // Usage: This ensures that value objects with the same properties are considered equal.

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        // Purpose: Generates a hash code for a value object based on its equality components.
        // Usage: Essential for efficient storage and retrieval of value objects in hash-based data structures.

        return GetEqualityComponents()
        .Select(x => x?.GetHashCode() ?? 0)
        .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        // Purpose: Provides an alternative implementation of the 'Equals' method.
        // Usage: Allows comparing a value object with another value object for equality based on their equality components.

        return Equals((object?)other);
    }
}


