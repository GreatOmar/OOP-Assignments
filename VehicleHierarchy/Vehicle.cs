namespace VehicleHierarchy;

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
