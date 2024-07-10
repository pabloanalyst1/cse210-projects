using System;
using System.Collections.Generic;

abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
}

class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}

class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }

    public override double GetArea()
    {
        return _width * _height;
    }
}

class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        // Create instances of shapes//
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 3, 6);
        Circle circle = new Circle("Green", 5);

        // Create a list of shapes//
        List<Shape> shapes = new List<Shape>
        {
            square,
            rectangle,
            circle
        };

        // Iterate through the list and display color and area for each shape//
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
