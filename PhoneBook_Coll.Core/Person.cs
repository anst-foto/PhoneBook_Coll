using System;

namespace PhoneBook_Coll.Core;

public class Person
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

    public string FullName => Patronymic is null 
        ? $"{LastName} {FirstName}" 
        : $"{LastName} {FirstName} {Patronymic}";

    public override int GetHashCode() => HashCode.Combine(LastName, FirstName, Patronymic);
}