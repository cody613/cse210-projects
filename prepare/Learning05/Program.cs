using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Purple", 4.5));
        shapes.Add(new Rectangle("Orange", 7, 3.2));
        shapes.Add(new Circle("Yellow", 2));

        Console.WriteLine("Shape Areas");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} | Area: {shape.GetArea():F2}");
        }
    }
}