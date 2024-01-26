using System;

class Program
{
    static void Main(string[] args)
    {
        string choice;
        
        Console.WriteLine("Welcome to scripture memorizer! Please select an option:");
        Console.WriteLine("1. Give me a random scripture ");
        Console.WriteLine("2. Type in Scripture reference");
        choice = Console.ReadLine();

        switch (choice) {
            case "1":
            Scripture scripture = new Scripture(new Reference("Genesis", 1, 1));
            break;

            case "2":
            break;

            default:
            break;
        }
    }
}