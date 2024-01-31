using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment assgn = new WritingAssignment("Felipe", "Math", "I did it");
        Console.WriteLine(assgn.GetSummary());
        Console.WriteLine(assgn.GetWritingInformation());
    }
}