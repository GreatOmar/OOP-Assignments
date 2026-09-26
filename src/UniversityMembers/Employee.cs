namespace UniversityMembers;

/// <summary>
/// An employee: adds EmployeeId and Salary to the shared Person state,
/// and is itself the base for Teacher (multi-level inheritance).
/// </summary>
internal class Employee : Person
{
    public string EmployeeId { get; }
    public decimal Salary { get; }

    public Employee(string name, string email, string employeeId, decimal salary)
        : base(name, email)
    {
        EmployeeId = employeeId;
        Salary = salary;
        Console.WriteLine($"[Employee ctor] id = {EmployeeId}, salary = {Salary:C}");
    }

    /// <summary>Specialized behavior only an Employee has.</summary>
    public void Work()
    {
        Console.WriteLine($"{Name} ({EmployeeId}) is working. Salary: {Salary:C}");
    }
}
