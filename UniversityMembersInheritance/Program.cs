using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("===== University Members — Inheritance & Constructor Chaining =====");
        Console.WriteLine("-- Constructor execution order (base -> derived) --");

        var student = new Student("Omar Ali", "omar.ali@uni.edu", "S-2026-001", 3.8);
        Console.WriteLine();
        var teacher = new Teacher("Sara Hassan", "sara.hassan@uni.edu", "E-1001", 45000m, "Object-Oriented Programming");

        Console.WriteLine();
        Console.WriteLine("-- Inherited and specialized methods --");
        student.DisplayBasicInfo();
        student.Study();

        Console.WriteLine();
        teacher.DisplayBasicInfo();
        teacher.Work();
        teacher.Teach();
    }
}

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

    public void Study()
    {
        Console.WriteLine($"{Name} (GPA: {GPA:F1}) is studying for the next exam.");
    }
}

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

    public void Work()
    {
        Console.WriteLine($"{Name} ({EmployeeId}) is working. Salary: {Salary:C}");
    }
}

internal class Teacher : Employee
{
    public string CourseName { get; }

    public Teacher(string name, string email, string employeeId, decimal salary, string courseName)
        : base(name, email, employeeId, salary)
    {
        CourseName = courseName;
        Console.WriteLine($"[Teacher ctor] course = {CourseName}");
    }

    public void Teach()
    {
        Console.WriteLine($"Prof. {Name} is teaching \"{CourseName}\".");
    }
}
