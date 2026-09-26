# OOP Hierarchies in C# (.NET)

Two classic object-oriented inheritance exercises implemented in clean,
single-file-per-class C#, built on the latest stable .NET with an explicit
`Program.Main` entry point (no top-level statements).

## Concepts Demonstrated

| Concept | Where |
|---|---|
| **Inheritance** | `Car`, `Bus`, `Motorcycle` extend `Vehicle`; `Student`, `Employee`, `Teacher` extend `Person` |
| **Constructor chaining** | Every derived class delegates shared state to its base with `base(...)` — logs show base constructors run first |
| **Multi-level inheritance** | `Teacher → Employee → Person` |
| **Polymorphism** | `List<Vehicle>` drives every vehicle through the base type; `List<Person>` displays every member the same way |
| **Method overriding** | `Vehicle.Start()` is `virtual` — derived classes can specialize the start behavior |
| **Encapsulation** | Get-only properties; state is set once in the constructor |

## Class Hierarchies

**Exercise 1 — Vehicles**

```
            Vehicle (Brand, Year)
            │       Start()
    ┌───────┼───────────────┐
   Car     Bus          Motorcycle
(Doors) (Capacity)   (HasSidecar)
```

**Exercise 2 — University Members**

```
            Person (Name, Email)
            │       DisplayBasicInfo()
    ┌───────┴────────┐
 Student          Employee (EmployeeId, Salary)
(StudentId,          │      Work()
  GPA)               │
  Study()          Teacher (CourseName)
                      Teach()
```

## Getting Started

```bash
dotnet build   # compile
dotnet run     # run the demonstration
```

Requires the .NET SDK (10.0 or any recent stable release).

## Sample Output

```
========== Exercise 2: University Members ==========
-- Constructor execution order (base -> derived) --
[Person ctor] Sara Hassan <sara.hassan@uni.edu>
[Employee ctor] id = E-1001, salary = $45,000.00
[Teacher ctor] course = Object-Oriented Programming
Prof. Sara Hassan is teaching "Object-Oriented Programming".
```

## Project Structure

```
Program.cs                     # explicit Main entry point / demo
OopHierarchy.csproj            # net10.0 console project
src/VehicleHierarchy/          # Vehicle, Car, Bus, Motorcycle
src/UniversityMembers/         # Person, Student, Employee, Teacher
```
