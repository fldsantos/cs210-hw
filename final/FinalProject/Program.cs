using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string inp = "";

        Board board;

        while (inp != "4")
        {
            Console.Clear();
            Console.WriteLine("Welcome to Terminal Chess!");
            Console.WriteLine("1. Play Chess");
            Console.WriteLine("2. Instructions");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                    board = new Board();
                    board.Run();
                    break;
                case "2":
                Console.WriteLine("To play Terminal Chess you need a friend willing to play on the same computer as you. Choose who is black and who is white.");
                Console.WriteLine("-White always goes first.");
                Console.WriteLine("");
                Console.WriteLine("To move a piece, you must type in the follow pattern: [LOCATION] to [DESTINATION]");
                Console.WriteLine("-Example: b3 to b4");
                Console.WriteLine("");
                Console.WriteLine("The program will not allow illegal chess moves.");
                Console.WriteLine("-Make sure you're moving the right piece!");
                Console.WriteLine("");
                Console.WriteLine("The game will end once one of the kings is captured, or you enemy surrenders.");
                Console.WriteLine("-to surrender, type 'surrender'");
                Console.WriteLine("");
                Console.WriteLine("Press 'enter' to go back to the main menu");
                inp = Console.ReadLine();
                    break;
                case "3":
                Console.Clear();
                Console.WriteLine("Developed by Felipe Dos Santos for the CSE210 class at BYU-Idaho.");
                Console.WriteLine("Press 'enter' to go back to the main menu");
                inp = Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Bye Bye!");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}