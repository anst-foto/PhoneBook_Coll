using System;
using System.Collections.Generic;
using System.IO;
using PhoneBook_Coll.Core;

var phoneBook = File.Exists("phonebook.json") 
    ? PhoneBook.LoadFromFile("phonebook.json") 
    : new PhoneBook();

var actions = new Dictionary<string, Procedure>()
{
    {"1", () =>
    {
        Console.Write("Введите фамилию: ");
        var lastName = Console.ReadLine();
        
        Console.Write("Введите имя: ");
        var firstName = Console.ReadLine();
        
        Console.Write("Введите отчество: ");
        var patronymic = Console.ReadLine();
        
        Console.Write("Введите номер телефона: ");
        var phoneNumber = Console.ReadLine();

        var person = new Person()
        {
            LastName = lastName,
            FirstName = firstName,
            Patronymic = patronymic
        };

        var result = phoneBook.TryAdd(person, phoneNumber);

        Console.WriteLine(result ? "Контакт успешно добавлен" : "Контакт с таким номером телефона уже существует");
    } },
    {"2", () =>
    {
        var list = phoneBook.GetPhoneBook();

        if (list.Count == 0)
        {
            Console.WriteLine("Контакты отсутствуют");
            return;
        }
        
        foreach (var item in list)
        {
            Console.WriteLine($"{item.Id}: {item.Person.FullName} {string.Join(", ", item.PhoneNumbers)}");
        }
    } },
    {"0", () =>
    {
        var list = phoneBook.GetPhoneBook();
        if (list.Count == 0)
        {
            Environment.Exit(0);
        }
        
        PhoneBook.SaveToFile("phonebook.json", phoneBook);
        Environment.Exit(0);
    }}
};

while (true)
{
    Console.WriteLine("1. Добавить контакт");
    Console.WriteLine("2. Просмотреть контакты");
    Console.WriteLine("0. Выход");
    Console.Write("Введите команду: ");
    var choice = Console.ReadLine();
    actions[choice]();
}

public delegate void Procedure();