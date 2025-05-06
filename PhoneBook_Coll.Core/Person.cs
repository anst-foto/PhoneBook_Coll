using System;
using System.Text.Json.Serialization;

namespace PhoneBook_Coll.Core;

public class Person : IEquatable<Person>
{
    private readonly string _firstName;
    public required string FirstName
    {
        get => _firstName;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentNullException(nameof(FirstName));
            _firstName = value.Trim();
        } 
    }
    
    private readonly string _lastName;
    public required string LastName
    {
        get => _lastName;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentNullException(nameof(LastName));
            _lastName = value.Trim();
        }
    }
    
    private readonly string? _patronymic;
    public string? Patronymic
    {
        get => _patronymic;
        init => _patronymic = value?.Trim() == string.Empty ? null : value?.Trim();
    }

    [JsonIgnore]
    public string FullName => Patronymic is null 
        ? $"{LastName} {FirstName}" 
        : $"{LastName} {FirstName} {Patronymic}";

    public override int GetHashCode()
    {
        return HashCode.Combine(_firstName, _lastName, _patronymic);
    }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _firstName == other._firstName && _lastName == other._lastName && _patronymic == other._patronymic;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Person)obj);
    }

    public static bool operator ==(Person? left, Person? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        return !Equals(left, right);
    }
}