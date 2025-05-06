using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PhoneBook_Coll.Core;

public class PhoneBook
{
    private readonly List<PhoneBookItem> _phoneBook;

    public PhoneBook()
    {
        _phoneBook = new List<PhoneBookItem>();
    }

    private PhoneBook(List<PhoneBookItem> phoneBook)
    {
        _phoneBook = new List<PhoneBookItem>(phoneBook);
    }

    public bool TryAdd(Person person, string phoneNumber)
    {
        var result = _phoneBook
            .SelectMany(phoneBookItem => phoneBookItem.PhoneNumbers)
            .Any(number => number == phoneNumber);
        if (result)
        {
            return false;
        }

        if (_phoneBook.Any(phoneBookItem => phoneBookItem.Person == person))
        {
            _phoneBook
                .Single(phoneBookItem => phoneBookItem.Person == person)
                .PhoneNumbers
                .Add(phoneNumber);
            return true;
        }
        
        _phoneBook.Add(new PhoneBookItem()
        {
            Id = Guid.NewGuid(),
            Person = person,
            PhoneNumbers = [phoneNumber]
        });
        return true;
    }

    public List<string>? GetPhones(Person person)
    {
        var phoneNumbers = _phoneBook
            .SingleOrDefault(p => p.Person == person)?.PhoneNumbers;
        return phoneNumbers;
    }

    public List<PhoneBookItem> GetPhoneBook()
    {
        return _phoneBook;
    }

    public static void SaveToFile(string path, PhoneBook phoneBook)
    {
        var file = new StreamWriter(path, false);
        var json = JsonSerializer.Serialize(phoneBook.GetPhoneBook());
        file.WriteLine(json);
        file.Close();
    }

    public static PhoneBook LoadFromFile(string path)
    {
        var file = new StreamReader(path);
        var json = file.ReadToEnd();
        file.Close();
        var list = JsonSerializer.Deserialize<List<PhoneBookItem>>(json)!;
        return new PhoneBook(list);
    }
}