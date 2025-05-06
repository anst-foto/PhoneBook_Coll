using System;

namespace PhoneBook_Coll;

public class Person
{
    private readonly string _firstName;
    public required string FirstName
    {
        get => _firstName;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Имя не может быть пустым");
            _firstName = value.Trim();
        } 
    }
    public required string LastName { get; init; }
    public string? Patronymic { get; init; }

    public string FullName => Patronymic is null 
        ? $"{LastName} {FirstName}" 
        : $"{LastName} {FirstName} {Patronymic}";

    public override int GetHashCode() => HashCode.Combine(LastName, FirstName, Patronymic);
}