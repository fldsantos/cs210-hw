using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Board b = new Board();
        b.DisplayBoard();
    }
}