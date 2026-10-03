# OOP Assignments in C# (.NET)

Four classic object-oriented inheritance exercises implemented in C#,
each an independent console project with its **entire exercise in a
single `Program.cs`** (no top-level statements — an explicit
`Program.Main` is the entry point), grouped under one .NET solution.

Two of them are different takes on the same "University Members"
hierarchy — see [the two University Members exercises](#the-two-university-members-exercises).

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

**Vehicle Hierarchy** (`VehicleHierarchy`)

```
            Vehicle (Brand, Year)
            │       virtual Start()
    ┌───────┼───────────────┐
   Car     Bus          Motorcycle
(Doors) (Capacity)   (HasSidecar)
```

**University Members — Polymorphism** (`UniversityMembers`)

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

**University Members — Inheritance & Constructor Chaining** (`UniversityMembersInheritance`)

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

**Shape Areas** (`ShapeAreas`) — *virtual, not abstract*

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
VehicleHierarchy/                # console app
  VehicleHierarchy.csproj
  Program.cs                     # entry point + Vehicle, Car, Bus, Motorcycle
UniversityMembers/               # console app
  UniversityMembers.csproj
  Program.cs                     # entry point + Person, Student, Employee, Teacher
UniversityMembersInheritance/    # console app
  UniversityMembersInheritance.csproj
  Program.cs                     # entry point + Person, Student, Employee, Teacher
ShapeAreas/                      # console app
  ShapeAreas.csproj
  Program.cs                     # entry point + Shape, Circle, Rectangle
```

## The Two University Members Exercises

Both build the same `Person → Student / Employee → Teacher` hierarchy,
but each demonstrates a different concept:

| | `UniversityMembers` | `UniversityMembersInheritance` |
|---|---|---|
| **Focus** | Polymorphism | Inheritance & constructor chaining |
| **Method style** | `virtual` / `override DisplayInfo()` | Plain methods, no overriding |
| **Constructor chaining** | Implicit (default constructors) | Explicit `base(...)` calls with constructor logs |
| **Polymorphic usage** | `List<Person>` + one `foreach`, `GetType()` runtime types, `DisplayMember(Person)` | One `Student` + one `Teacher`, calling inherited **and** specialized methods (`Study()`, `Work()`, `Teach()`) |
| **What it proves** | The runtime type picks the override | Base constructors always run first: `Person → Employee → Teacher` |

## Getting Started

Requires the .NET SDK (10.0 or any recent stable release).

Build everything at once:

```bash
dotnet build OopHierarchies.sln
```

Run each exercise independently:

```bash
# Vehicle Hierarchy
dotnet run --project VehicleHierarchy

# University Members (Polymorphism)
dotnet run --project UniversityMembers

# University Members (Inheritance & Constructor Chaining)
dotnet run --project UniversityMembersInheritance

# Shape Areas
dotnet run --project ShapeAreas
```

## Sample Output

```
===== University Members — Inheritance & Constructor Chaining =====
-- Constructor execution order (base -> derived) --
[Person ctor] Sara Hassan <sara.hassan@uni.edu>
[Employee ctor] id = E-1001, salary = $45,000.00
[Teacher ctor] course = Object-Oriented Programming
Prof. Sara Hassan is teaching "Object-Oriented Programming".

===== University Members — Polymorphism =====
Runtime type: Student
Student: Omar Ali | ID: 1

Runtime type: Employee
Employee: Mona Adel | Salary: $5,500.00

Runtime type: Teacher
Teacher: Sara Hassan | Salary: $7,000.00 | Course: Object-Oriented Programming

===== Shape Areas =====
Circle | Area = 28.274333882308138
Rectangle | Area = 20
```
