using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 2));
        shapes.Add(new Rectangle("green", 2, 3));
        shapes.Add(new Circle("blue", 3));

        for(int i = 0; i < shapes.Count ; i++) {
            Console.WriteLine(shapes[i].GetColor());
            Console.WriteLine(shapes[i].GetArea());
        }
    
    }
}