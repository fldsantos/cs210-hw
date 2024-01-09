using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        String fName = Console.ReadLine();

        Console.WriteLine("What is your last name? ");
        String lName = Console.ReadLine();

        Console.WriteLine($"Your name is {lName}, {fName} {lName}.");
    }
}