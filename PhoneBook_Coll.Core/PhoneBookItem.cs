using System;
using System.Collections.Generic;

namespace PhoneBook_Coll.Core;

public class PhoneBookItem : IEquatable<PhoneBookItem>
{
    public Guid Id { get; init; }
    public required Person Person { get; init; }
    public required List<string> PhoneNumbers { get; init; }

    public bool Equals(PhoneBookItem? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && Person.Equals(other.Person);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((PhoneBookItem)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Person);
    }

    public static bool operator ==(PhoneBookItem? left, PhoneBookItem? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(PhoneBookItem? left, PhoneBookItem? right)
    {
        return !Equals(left, right);
    }
}