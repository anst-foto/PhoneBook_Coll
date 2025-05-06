using PhoneBook_Coll.Core;

namespace PhoneBook_Coll.Test;

public class PhoneBookTest
{
    [Fact]
    public void TryAdd_PositiveTest()
    {
        var phoneBook = new PhoneBook();
        var result = phoneBook.TryAdd(
            person: new Person()
        {
            FirstName = "Test",
            LastName = "Test"
        }, 
            phoneNumber: "+71231234567");
        
        Assert.True(result);
    }
    
    [Fact]
    public void TryAdd_NegativeTest()
    {
        var phoneBook = new PhoneBook();
        phoneBook.TryAdd(
            person: new Person()
            {
                FirstName = "Test",
                LastName = "Test"
            }, 
            phoneNumber: "+71231234567");
        var result = phoneBook.TryAdd(
            person: new Person()
            {
                FirstName = "Test",
                LastName = "Test"
            }, 
            phoneNumber: "+71231234567");
        
        Assert.False(result);
    }
}