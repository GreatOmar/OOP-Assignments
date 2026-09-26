namespace VehicleHierarchy;

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
