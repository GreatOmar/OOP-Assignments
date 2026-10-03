using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("===== Shape Areas =====");

        var shapes = new List<Shape>
        {
            new Circle(3),
            new Rectangle(4, 5)
        };

        Console.WriteLine();

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} | Area = {shape.CalculateArea()}");
        }
    }
}

internal class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

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
