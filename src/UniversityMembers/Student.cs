namespace UniversityMembers;

/// <summary>
/// A student: adds StudentId and GPA to the shared Person state.
/// </summary>
internal class Student : Person
{
    public string StudentId { get; }
    public double GPA { get; }

    public Student(string name, string email, string studentId, double gpa)
        : base(name, email)
    {
        StudentId = studentId;
        GPA = gpa;
        Console.WriteLine($"[Student ctor] id = {StudentId}, GPA = {GPA}");
    }

    /// <summary>Specialized behavior only a Student has.</summary>
    public void Study()
    {
        Console.WriteLine($"{Name} (GPA: {GPA:F1}) is studying for the next exam.");
    }
}
