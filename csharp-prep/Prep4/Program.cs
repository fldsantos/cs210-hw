using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNumber = 1;

        while (userNumber != 0) {
            Console.WriteLine("Enter a Number: ");
            userNumber = Convert.ToInt32(Console.ReadLine());
            numbers.Append(userNumber);
        }

        numbers.ForEach(Console.WriteLine);
    }
}