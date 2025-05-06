using System;
using PhoneBook_Coll.Core;

namespace PhoneBook_Coll.Test;

public class PersonTest
{
    [Fact]
    public void FirstName_PositiveTest()
    {
        var person = new Person()
        {
            FirstName = "Test",
            LastName = "Test"
        };
        
        const string expected = "Test";
        var actual = person.FirstName;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void FirstNameWithSpace_PositiveTest()
    {
        var person = new Person()
        {
            FirstName = " Test  ",
            LastName = "Test"
        };
        
        const string expected = "Test";
        var actual = person.FirstName;
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FirstName_NegativeTest()
    {
        Assert.Throws<ArgumentNullException>(() => new Person()
        {
            FirstName = "",
            LastName = "Test"
        });
    }
    
    [Fact]
    public void LastName_PositiveTest()
    {
        var person = new Person()
        {
            FirstName = "Test",
            LastName = "Test"
        };
        
        const string expected = "Test";
        var actual = person.LastName;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void LastNameWithSpace_PositiveTest()
    {
        var person = new Person()
        {
            FirstName = " Test  ",
            LastName = "  Test  "
        };
        
        const string expected = "Test";
        var actual = person.LastName;
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LastName_NegativeTest()
    {
        Assert.Throws<ArgumentNullException>(() => new Person()
        {
            FirstName = "Test",
            LastName = ""
        });
    }

    [Fact]
    public void PatronymicNull_PositiveTest()
    {
        var person = new Person
        {
            FirstName = "Test",
            LastName = "Test",
            Patronymic = ""
        };

        Assert.Null(person.Patronymic);
    }
    
    [Fact]
    public void Patronymic_PositiveTest()
    {
        var person = new Person
        {
            FirstName = "Test",
            LastName = "Test",
            Patronymic = "  Test  "
        };
        
        const string expected = "Test";
        var actual = person.Patronymic;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FullName_Test()
    {
        var person1 = new Person
        {
            FirstName = "Test",
            LastName = "Test"
        };
        
        var person2 = new Person
        {
            FirstName = "Test",
            LastName = "Test",
            Patronymic = "Test"
        };
        
        const string expected1 = "Test Test";
        const string expected2 = "Test Test";
        
        var actual1 = person1.FullName;
        var actual2 = person1.FullName;
        
        Assert.Multiple(
            () => Assert.Equal(expected1, actual1), 
            () => Assert.Equal(expected2, actual2));
    }

    [Fact]
    public void GetHashCode_Test()
    {
        var person1 = new Person
        {
            FirstName = "Test",
            LastName = "Test",
            Patronymic = "Test"
        };
        
        var person2 = new Person
        {
            FirstName = "Test",
            LastName = "Test",
            Patronymic = "Test"
        };
        
        var hash1 = person1.GetHashCode();
        var hash2 = person2.GetHashCode();
        
        Assert.Multiple(
            () => Assert.Equal(hash1, HashCode.Combine(person1.LastName, person1.FirstName, person1.Patronymic)),
            () => Assert.Equal(hash2, HashCode.Combine(person2.LastName, person2.FirstName, person2.Patronymic)),
            () => Assert.Equal(hash1, hash2));
    }
}