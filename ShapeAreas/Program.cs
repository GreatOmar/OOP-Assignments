// Explicit entry point (no top-level statements).
// Exercise 18: Shape Areas — all classes in this single file.
// Note: virtual, not abstract — abstract classes belong to the next lecture.
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("===== Exercise 18: Shape Areas =====");

        var shapes = new List<Shape>
        {
            new Circle(3),
            new Rectangle(4, 5)
        };

        // One loop over the base type: each call dispatches to the
        // override of the runtime type.
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} | Area = {shape.CalculateArea()}");
        }
    }
}

/// <summary>
/// Base class with a virtual area calculation; instances of Shape
/// itself report an area of 0.
/// </summary>
internal class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

/// <summary>
/// A circle: adds Radius and overrides the area formula (πr²).
/// </summary>
internal class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

/// <summary>
/// A rectangle: adds Width and Height and overrides the area
/// formula (w × h).
/// </summary>
internal class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}
