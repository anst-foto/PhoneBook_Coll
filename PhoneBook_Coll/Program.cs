using System;
using PhoneBook_Coll.Core;

/*var phoneBook = new PhoneBook();
phoneBook.TryAdd(new Person()
{
    FirstName = "Ivan",
    LastName = "Ivanov",
    Patronymic = "Ivanovich"
}, "+79999999999");
phoneBook.TryAdd(new Person()
{
    FirstName = "Ivan",
    LastName = "Ivanov",
    Patronymic = "Ivanovich"
}, "+71231231212");
phoneBook.TryAdd(new Person()
{
    FirstName = "Petr",
    LastName = "Ivanov",
    Patronymic = "Ivanovich"
}, "+71234567890");

PhoneBook.SaveToFile("phonebook.json", phoneBook);*/
var phoneBook = PhoneBook.LoadFromFile("phonebook.json");
foreach (var phoneBookItem in phoneBook.GetPhoneBook())
{
    Console.WriteLine($"{phoneBookItem.Id}: {phoneBookItem.Person.FullName}, {string.Join(", ", phoneBookItem.PhoneNumbers)}");
}
