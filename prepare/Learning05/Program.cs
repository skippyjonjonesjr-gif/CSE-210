using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4.0));
        shapes.Add(new Rectangle("Blue", 5.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {shape.GetType().Name} has a color of {color} and an area of {area:F2}.");
        }
    }
}
