namespace UniversityMembers;

/// <summary>
/// A teacher: an Employee who also has a CourseName — the deepest
/// link of the chain, exercising multi-level constructor chaining
/// (Teacher -> Employee -> Person).
/// </summary>
internal class Teacher : Employee
{
    public string CourseName { get; }

    public Teacher(string name, string email, string employeeId, decimal salary, string courseName)
        : base(name, email, employeeId, salary)
    {
        CourseName = courseName;
        Console.WriteLine($"[Teacher ctor] course = {CourseName}");
    }

    /// <summary>Specialized behavior only a Teacher has.</summary>
    public void Teach()
    {
        Console.WriteLine($"Prof. {Name} is teaching \"{CourseName}\".");
    }
}
