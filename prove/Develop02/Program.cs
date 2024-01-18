//This Program has all the core requirements, and I addressed the extra requirements by
//Letting the user decide whether or not they want to use a prompt, and also by letting them
//delete their entries.

using System;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        string choice = "";

        Journal myJournal = new Journal();
        myJournal.LoadEntries();

        while (running) {
            System.Console.WriteLine("Please select one of the following choices:");
            System.Console.WriteLine("1. Write");
            System.Console.WriteLine("2. Display");
            System.Console.WriteLine("3. Load");
            System.Console.WriteLine("4. Save");
            System.Console.WriteLine("5. Delete");
            System.Console.WriteLine("6. Quit");

            choice = Console.ReadLine();
            
            switch (choice) {
                case "1":
                    System.Console.WriteLine("Would you like to generate a prompt? (y/n)");
                    choice = Console.ReadLine();
                    if (choice=="y") {
                        myJournal.AddNewEntry(true);
                        Console.WriteLine(myJournal._entries[myJournal._entries.Count-1]._prompt);
                        myJournal.AddTextToEntry(Console.ReadLine());
                    } else {
                        myJournal.AddNewEntry();
                        myJournal.AddTextToEntry(Console.ReadLine());
                    }
                    
                    break;

                case "2":
                    myJournal.DisplayAllEntries();
                    break;

                case "3":
                    Console.WriteLine("Loading...");
                    myJournal.LoadEntries();
                    break;

                case "4":
                    Console.WriteLine("Saving...");
                    myJournal.SaveEntries();
                    break;

                case "5":
                    Console.WriteLine("Which Entry would you like to delete? ");
                    myJournal.DisplayAllEntries();

                    myJournal.removeEntry(Int32.Parse(Console.ReadLine()));
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Not a valid option. ");
                    break;
            }
        }
    }
}