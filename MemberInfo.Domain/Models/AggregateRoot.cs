using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberInfo.Domain.Models;
// This is a namespace declaration, which organizes your code into a specific scope.

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    // Purpose: Defines a base class for aggregate roots, which are entities at the root of aggregates in domain-driven design.
    // Usage: Aggregate roots are the entry points for accessing other related entities within an aggregate.

    protected AggregateRoot(TId id) : base(id)
    {
        // This is a constructor for the 'AggregateRoot' class.
        // It takes an 'id' of type 'TId' as a parameter and passes it to the base class constructor.

        // Purpose: Initializes an 'AggregateRoot' with a unique identifier.
        // Usage: Typically, 'AggregateRoot' represents an entity at the root of an aggregate in domain-driven design.
        // It extends the functionality of the 'Entity' class for such root entities.
    }
}



