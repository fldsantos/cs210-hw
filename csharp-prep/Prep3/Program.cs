using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        int userNumber = 0;

        Console.WriteLine($"{number} I'm thinking of a magic number! Can you guess it?");
        userNumber = Convert.ToInt32(Console.ReadLine());

        while (userNumber != number) {
            if (number > userNumber) {
                Console.WriteLine("Higher! Try Again.");
                userNumber = Convert.ToInt32(Console.ReadLine());
            } else {
                Console.WriteLine("Lower! Try Again.");
                userNumber = Convert.ToInt32(Console.ReadLine());
            }
        } 

        Console.WriteLine("You Guessed It!");
    }
}