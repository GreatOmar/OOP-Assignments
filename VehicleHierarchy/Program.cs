// Explicit entry point (no top-level statements).
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
    }
}
