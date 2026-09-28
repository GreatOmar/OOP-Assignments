// Explicit entry point (no top-level statements).
// Exercise 2: University members — all classes in this single file.
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("========== Exercise 2: University Members ==========");
        Console.WriteLine("-- Constructor execution order (base -> derived) --");
        var student = new Student("Omar Ali", "omar.ali@uni.edu", studentId: "S-2026-001", gpa: 3.8);
        Console.WriteLine();
        var teacher = new Teacher(
            "Sara Hassan", "sara.hassan@uni.edu",
            employeeId: "E-1001", salary: 45000m, courseName: "Object-Oriented Programming");

        Console.WriteLine();
        Console.WriteLine("-- Behavior: inherited + specialized methods --");
        student.DisplayBasicInfo(); // inherited from Person
        student.Study();            // specialized

        Console.WriteLine();
        teacher.DisplayBasicInfo(); // inherited from Person (two levels up)
        teacher.Work();             // inherited from Employee
        teacher.Teach();            // specialized

        Console.WriteLine();
        // Polymorphism: treat every member as its base type Person.
        Console.WriteLine("-- Polymorphic collection (List<Person>) --");
        var members = new List<Person> { student, teacher };
        foreach (Person member in members)
        {
            member.DisplayBasicInfo();
        }
    }
}

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

/// <summary>
/// An employee: adds EmployeeId and Salary to the shared Person state,
/// and is itself the base for Teacher (multi-level inheritance).
/// </summary>
internal class Employee : Person
{
    public string EmployeeId { get; }
    public decimal Salary { get; }

    public Employee(string name, string email, string employeeId, decimal salary)
        : base(name, email)
    {
        EmployeeId = employeeId;
        Salary = salary;
        Console.WriteLine($"[Employee ctor] id = {EmployeeId}, salary = {Salary:C}");
    }

    /// <summary>Specialized behavior only an Employee has.</summary>
    public void Work()
    {
        Console.WriteLine($"{Name} ({EmployeeId}) is working. Salary: {Salary:C}");
    }
}

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
