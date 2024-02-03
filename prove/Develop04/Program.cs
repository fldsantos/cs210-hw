using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity ba = new BreathingActivity();
        ReflectionActivity ra = new ReflectionActivity();
        ListingActivity la = new ListingActivity();

        string choice = "";

        while (choice!= "4") {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine(" 1.Start Breathing activity");
            Console.WriteLine(" 2.Start Reflection activity");
            Console.WriteLine(" 3.Start Listing activity");
            Console.WriteLine(" 4.Quit");
            Console.WriteLine("Select a choice from the menu: ");

            choice = Console.ReadLine();
            Console.Clear();

            switch (choice) {
            case "1":
                ba.Run();
                break;
            case "2":
                ra.Run();
                break;
            case "3":
                la.Run();
                break;
            case "quit":
                Console.WriteLine("Bye bye!");
                Thread.Sleep(1000);
                break;
            case "4":
                Console.WriteLine("Bye bye!");
                Thread.Sleep(1000);
                break;
            default:
                Console.WriteLine("Not a valid option.");
                Thread.Sleep(1000);
                break;
            }

            Console.Clear();
        }
    }
}