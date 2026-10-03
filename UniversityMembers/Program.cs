// Explicit entry point (no top-level statements).
// Exercise 17: University Members — all classes in this single file.
// Focus: virtual/override polymorphism, GetType() vs static type,
//        and polymorphism through a method parameter.
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("===== Exercise 17: University Members =====");

        // One object of each type, stored through the base type.
        var members = new List<Person>
        {
            new Student("Omar Ali", 1),
            new Employee("Mona Adel", 5500m),
            new Teacher("Sara Hassan", 7000m, "Object-Oriented Programming")
        };

        Console.WriteLine("-- One foreach loop, virtual DisplayInfo() --");
        foreach (Person member in members)
        {
            // GetType() returns the RUNTIME type, not the declared type —
            // proof that the override, not the variable type, decides behavior.
            Console.WriteLine($"Runtime type: {member.GetType().Name}");
            member.DisplayInfo();
            Console.WriteLine();
        }

        Console.WriteLine("-- Method accepting a base Person --");
        // All three derive from Person, so all three fit the parameter.
        DisplayMember(members[0]);
        DisplayMember(members[1]);
        DisplayMember(members[2]);
    }

    /// <summary>
    /// Accepts ANY Person (or derived object) and lets the runtime
    /// type pick the right override — polymorphism via a parameter.
    /// </summary>
    private static void DisplayMember(Person person)
    {
        Console.WriteLine($"[{person.GetType().Name} passed to DisplayMember]");
        person.DisplayInfo();
    }
}

/// <summary>
/// Base class: shared state (Name) and a virtual method that every
/// derived class may customize with override.
/// </summary>
internal class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Person: {Name}");
    }
}

/// <summary>
/// A student: adds StudentId and overrides DisplayInfo().
/// </summary>
internal class Student : Person
{
    public int StudentId { get; }

    public Student(string name, int studentId)
        : base(name)
    {
        StudentId = studentId;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name} | ID: {StudentId}");
    }
}

/// <summary>
/// An employee: adds Salary and overrides DisplayInfo().
/// </summary>
internal class Employee : Person
{
    public decimal Salary { get; }

    public Employee(string name, decimal salary)
        : base(name)
    {
        Salary = salary;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Employee: {Name} | Salary: {Salary:C}");
    }
}

/// <summary>
/// A teacher: an Employee who also adds CourseName and overrides
/// DisplayInfo() with its own version.
/// </summary>
internal class Teacher : Employee
{
    public string CourseName { get; }

    public Teacher(string name, decimal salary, string courseName)
        : base(name, salary)
    {
        CourseName = courseName;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Teacher: {Name} | Salary: {Salary:C} | Course: {CourseName}");
    }
}
