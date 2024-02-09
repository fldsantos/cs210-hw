using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager gm = new GoalManager();
        String choice = "";

        while (choice != "6")
        {
            Console.Clear();

            gm.DisplayPlayerInfo();

            gm.Start();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    gm.CreateGoal();
                    break;

                case "2":
                    gm.ListGoalDetails();
                    break;

                case "3":
                    gm.SaveGoals();
                    break;

                case "4":
                    gm.LoadGoals();
                    break;

                case "5":
                    gm.ListGoalNames();
                    choice = Console.ReadLine();
                    gm.RecordEvent(Int32.Parse(choice));
                    break;

                case "6":
                    Console.WriteLine("bye bye!");
                    break;

            }
        }


    }
}