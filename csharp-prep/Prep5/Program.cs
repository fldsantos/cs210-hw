using System;

class Program
{
    static void Main(string[] args)
    {
        void DisplayWelcome() {
            Console.WriteLine("Welcome to the Program!");
        }

        String PromptUserName() {
            Console.WriteLine("Please enter your name: ");
            return Console.ReadLine();
        }

        int PromptUserNumber() {
            Console.WriteLine("Please enter your favorite number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        int SquareNumber (int number) {
            return  Convert.ToInt32(Math.Pow(number, 2));
        }

        void DisplayResult(String name, int number) {
            Console.WriteLine($"{name}, the square of your number is {SquareNumber(number)}");
        }
        
        DisplayWelcome();
        DisplayResult(PromptUserName(), PromptUserNumber());
    }
}   