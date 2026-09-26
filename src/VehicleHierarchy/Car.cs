namespace VehicleHierarchy;

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
