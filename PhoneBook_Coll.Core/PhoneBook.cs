using System.Collections.Generic;

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
        foreach (var phones in _phoneBook.Values)
        {
            foreach (var phone in phones)
            {
                if (phone == phoneNumber) return false;
            }
        }
        
        if (_phoneBook.ContainsKey(person))
        {
            _phoneBook[person].Add(phoneNumber);
            return true;
        }
        
        _phoneBook.Add(person, new List<string> {phoneNumber});
        return true;
    }
}