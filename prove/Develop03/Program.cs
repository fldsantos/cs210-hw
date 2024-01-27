using System;

class Program
{
    static void Main(string[] args)
    {
        List<Reference> references = new List<Reference>();
        references.Add(new Reference("1 Nephi", 3, 7));
        references.Add(new Reference("Moses", 1, 39));
        references.Add(new Reference("2 Nephi", 9, 28, 29));
        references.Add(new Reference("Alma", 34, 32, 34));

        Scripture chosenScripture;

        string choice = "";
        
        Console.Clear();
        Console.WriteLine("Welcome to Scripture memorizer! Please choose an option:");
        Console.WriteLine("1. Choose a scripture from the list");
        Console.WriteLine("2. Get a random scripture");
        choice = Console.ReadLine();

        if (choice == "1") {
            Console.Clear();
            Console.WriteLine("Choose one of the following scriptures: ");
            int count = 1;

            foreach (Reference reference in references) {
                Console.WriteLine($"{count}. {reference.GetDisplayText()}");
                count++;
            }

            choice = Console.ReadLine();
            chosenScripture = new Scripture(references[Int32.Parse(choice)-1]);

        } else {
            Random rnd = new Random();
            chosenScripture = new Scripture(references[rnd.Next(0, references.Count)]);
        }

        while((!chosenScripture.IsCompletelyHidden())) {
            Console.Clear();
            Console.WriteLine(chosenScripture.GetDisplayText());
            Console.WriteLine("Type 'quit' to exit the apllication");
            chosenScripture.HideRandomWords(15);
            choice = Console.ReadLine();
            if(choice.Equals("quit")) {
                break;
            }
        }

        if (chosenScripture.IsCompletelyHidden()) {
            Console.Clear();
            Console.WriteLine(chosenScripture.GetDisplayText());
            Console.WriteLine("Type 'quit' to exit the apllication");
            choice = Console.ReadLine();
        }

    }
}