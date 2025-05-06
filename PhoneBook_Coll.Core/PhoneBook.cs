using System.Collections.Generic;
using System.Linq;

namespace PhoneBook_Coll.Core;

public class PhoneBook
{
    private readonly Dictionary<Person, List<string>> _phoneBook;

    public PhoneBook()
    {
        _phoneBook = new Dictionary<Person, List<string>>();
    }

    public bool TryAdd(Person person, string phoneNumber)
    {
        if (_phoneBook.Values.Any((phones) => phones.Any((phone) => phone == phoneNumber)))
        {
            return false;
        }
        
        if (_phoneBook.TryGetValue(person, out var value))
        {
            value.Add(phoneNumber);
            return true;
        }
        
        _phoneBook.Add(person, [phoneNumber]);
        return true;
    }
}