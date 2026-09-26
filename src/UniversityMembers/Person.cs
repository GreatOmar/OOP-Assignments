namespace UniversityMembers;

/// <summary>
/// Base class of the hierarchy. Holds the shared state (Name, Email)
/// and behavior (DisplayBasicInfo) common to every university member.
/// </summary>
internal class Person
{
    public string Name { get; }
    public string Email { get; }

    public Person(string name, string email)
    {
        Name = name;
        Email = email;
        Console.WriteLine($"[Person ctor] {Name} <{Email}>");
    }

    public void DisplayBasicInfo()
    {
        Console.WriteLine($"{Name} | Email: {Email}");
    }
}
