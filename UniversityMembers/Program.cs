using System;
using System.Collections.Generic;

internal class Program
{
    private static void DisplayMember(Person person)
    {
        Console.WriteLine($"[{person.GetType().Name} passed to DisplayMember]");
        person.DisplayInfo();
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("===== University Members =====");

        var members = new List<Person>
        {
            new Student("Omar Ali", 1),
            new Employee("Mona Adel", 5500m),
            new Teacher("Sara Hassan", 7000m, "Object-Oriented Programming")
        };

        Console.WriteLine();

        foreach (Person member in members)
        {
            Console.WriteLine($"Runtime type: {member.GetType().Name}");
            member.DisplayInfo();
            Console.WriteLine();
        }

        DisplayMember(members[0]);
        DisplayMember(members[1]);
        DisplayMember(members[2]);
    }
}

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
