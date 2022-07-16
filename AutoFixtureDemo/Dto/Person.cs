namespace AutoFixtureDemo.Dto;

public class Person
{
    public Person(string nationalId, string firstName, string lastName)
    {
        NationalId = nationalId;
        FirstName = firstName;
        LastName = lastName;
    }

    public string NationalId { get; }
    public string FirstName { get; }
    public string LastName { get; }
}