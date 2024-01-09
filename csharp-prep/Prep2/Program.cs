using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int score = Convert.ToInt32(Console.ReadLine());
        String grade = "";

        if (score >= 90) {
            grade = "A";
        } else if (score >= 80) {
            grade = "B";
        } else if (score >= 70) {
            grade = "C";
        } else if (score >= 60) {
            grade = "D";
        } else if (score < 60) {
            grade = "F";
        }

        Console.WriteLine($"Grade: {grade}");

        if(score >= 70) {
            Console.WriteLine("Congratulations! You passed!");
        } else {
            Console.WriteLine("Unfortunately, you were not approved.");
        }
        
    }
}