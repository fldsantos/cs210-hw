using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNumber = 1;

        int sum = 0;
        int average = 0;
        int largest = 0;

        while (userNumber != 0) {
            Console.WriteLine("Enter a Number: ");
            userNumber = Convert.ToInt32(Console.ReadLine());
            numbers.Add(userNumber);
        }
        numbers.RemoveAt(numbers.Count - 1);

        foreach (int number in numbers) {
            sum += number;
        }

        average = sum / numbers.Count;
        largest = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest is {largest}");
    }
}