# OOP Assignments in C# (.NET)

Three classic object-oriented inheritance exercises implemented in C#,
each an independent console project with its **entire exercise in a
single `Program.cs`** (no top-level statements — an explicit
`Program.Main` is the entry point), grouped under one .NET solution.

## Concepts Demonstrated

| Concept | Where |
|---|---|
| **Inheritance** | `Car`, `Bus`, `Motorcycle` extend `Vehicle`; `Student`, `Employee`, `Teacher` extend `Person`; `Circle`, `Rectangle` extend `Shape` |
| **Constructor chaining** | Derived classes delegate shared state to their base with `base(...)` — logs show base constructors run first |
| **Multi-level inheritance** | `Teacher → Employee → Person` |
| **Virtual methods & overriding** | `Vehicle.Start()`, `Person.DisplayInfo()`, `Shape.CalculateArea()` are `virtual`; derived classes `override` them |
| **Polymorphism** | `List<Vehicle>`, `List<Person>`, `List<Shape>` iterate base-type collections — the runtime type picks the override |
| **Runtime type inspection** | `GetType().Name` printed inside the loops to compare runtime vs declared types |
| **Polymorphic parameters** | `DisplayMember(Person)` accepts any derived type and dispatches to the right override |
| **Encapsulation** | Get-only properties; state is set once in the constructor |

## Class Hierarchies

**Exercise 1 — Vehicles** (`VehicleHierarchy`)

```
            Vehicle (Brand, Year)
            │       virtual Start()
    ┌───────┼───────────────┐
   Car     Bus          Motorcycle
(Doors) (Capacity)   (HasSidecar)
```

**Exercise 17 — University Members** (`UniversityMembers`)

```
            Person (Name)
            │       virtual DisplayInfo()
    ┌───────┼──────────────┐
 Student        Employee (Salary)
(StudentId)        │       override DisplayInfo()
  override         │
DisplayInfo()    Teacher (CourseName)
                   override DisplayInfo()
```

**Exercise 18 — Shape Areas** (`ShapeAreas`) — *virtual, not abstract*

```
            Shape
            │       virtual CalculateArea()
    ┌───────┴────────┐
  Circle          Rectangle
 (Radius)      (Width, Height)
  override        override
CalculateArea() CalculateArea()
```

## Project Structure

One console project per exercise; each keeps its **entire exercise in a
single `Program.cs`** — entry point plus all hierarchy classes in one file:

```
OopHierarchies.sln               # solution wiring the projects together
VehicleHierarchy/                # Exercise 1 console app
  VehicleHierarchy.csproj
  Program.cs                     # entry point + Vehicle, Car, Bus, Motorcycle
UniversityMembers/               # Exercise 17 console app
  UniversityMembers.csproj
  Program.cs                     # entry point + Person, Student, Employee, Teacher
ShapeAreas/                      # Exercise 18 console app
  ShapeAreas.csproj
  Program.cs                     # entry point + Shape, Circle, Rectangle
```

## Getting Started

Requires the .NET SDK (10.0 or any recent stable release).

Build everything at once:

```bash
dotnet build OopHierarchies.sln
```

Run each exercise independently:

```bash
# Exercise 1: Vehicle Hierarchy
dotnet run --project VehicleHierarchy

# Exercise 17: University Members
dotnet run --project UniversityMembers

# Exercise 18: Shape Areas
dotnet run --project ShapeAreas
```

## Sample Output

```
===== Exercise 17: University Members =====
-- One foreach loop, virtual DisplayInfo() --
Runtime type: Student
Student: Omar Ali | ID: 1

Runtime type: Employee
Employee: Mona Adel | Salary: $5,500.00

Runtime type: Teacher
Teacher: Sara Hassan | Salary: $7,000.00 | Course: Object-Oriented Programming

===== Exercise 18: Shape Areas =====
Circle | Area = 28.274333882308138
Rectangle | Area = 20
```
