// Explicit entry point (no top-level statements).
// Exercise 1: Vehicle hierarchy — all classes in this single file.
using System;

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
    }
}

/// <summary>
/// Base class of the hierarchy. Holds the shared state (Brand, Year)
/// and behavior (Start) common to every vehicle.
/// </summary>
internal class Vehicle
{
    public string Brand { get; }
    public int Year { get; }

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine($"The {Year} {Brand} vehicle is starting...");
    }
}

/// <summary>
/// A car: adds its own specialized state (NumberOfDoors) to the
/// shared Vehicle state via constructor chaining (base).
/// </summary>
internal class Car : Vehicle
{
    public int NumberOfDoors { get; }

    public Car(string brand, int year, int numberOfDoors)
        : base(brand, year)
    {
        NumberOfDoors = numberOfDoors;
        Console.WriteLine($"[Car ctor] doors = {NumberOfDoors}");
    }
}

/// <summary>
/// A bus: adds passenger Capacity to the shared Vehicle state.
/// </summary>
internal class Bus : Vehicle
{
    public int Capacity { get; }

    public Bus(string brand, int year, int capacity)
        : base(brand, year)
    {
        Capacity = capacity;
        Console.WriteLine($"[Bus ctor] capacity = {Capacity}");
    }
}

/// <summary>
/// A motorcycle: adds a boolean flag (HasSidecar) to the shared Vehicle state.
/// </summary>
internal class Motorcycle : Vehicle
{
    public bool HasSidecar { get; }

    public Motorcycle(string brand, int year, bool hasSidecar)
        : base(brand, year)
    {
        HasSidecar = hasSidecar;
        Console.WriteLine($"[Motorcycle ctor] sidecar = {(HasSidecar ? "yes" : "no")}");
    }
}
