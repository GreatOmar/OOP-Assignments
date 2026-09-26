// Explicit entry point (no top-level statements).
using UniversityMembers;
using VehicleHierarchy;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("========== Exercise 1: Vehicle Hierarchy ==========");
        var car = new Car("Toyota", 2024, 4);
        var bus = new Bus("Mercedes", 2023, 50);
        var bike = new Motorcycle("Harley-Davidson", 2022, hasSidecar: true);

        Console.WriteLine();
        var vehicles = new List<Vehicle> { car, bus, bike };
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Start(); // polymorphic dispatch through the base type
        }

        Console.WriteLine();
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
