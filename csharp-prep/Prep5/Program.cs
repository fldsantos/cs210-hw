using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult(PromptUserName(), PromptUserNumber());
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return Convert.ToInt32(Math.Pow(number, 2));
    }

    static void DisplayResult(String name, int number)
    {
        Console.WriteLine($"{name}, the square of your number is {SquareNumber(number)}");
    }
}