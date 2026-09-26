namespace VehicleHierarchy;

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
