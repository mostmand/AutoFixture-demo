namespace AutoFixtureDemo.Entities;

public class Person
{
    public Person(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}