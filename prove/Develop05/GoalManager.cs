using System.IO;

class GoalManager {
    
    private List<Goal> _goals;
    private int _score;
    private double _level;

    public GoalManager() {
        _goals = new List<Goal>();
        _level = 0;
    }

    public void Start(){
        Console.WriteLine("Menu Options:"); 
        Console.WriteLine(" 1. Create New Goal"); 
        Console.WriteLine(" 2. List Goals"); 
        Console.WriteLine(" 3. Save Goals"); 
        Console.WriteLine(" 4. Load Goals"); 
        Console.WriteLine(" 5. Record Event"); 
        Console.WriteLine(" 6. Quit"); 
        Console.Write("Select a choice from the menu: "); 
    }
    public void DisplayPlayerInfo(){
        Console.WriteLine($"Your level is {Math.Floor(_level)}.");
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"");
    }
    public void ListGoalNames(){
        Console.Clear();
        Console.WriteLine("The goals are: ");
        int i = 1;
        foreach(Goal goal in _goals) {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }
    public void ListGoalDetails(){
        Console.Clear();
        Console.WriteLine("The goals are: ");
        int i = 1;
        foreach(Goal goal in _goals) {
            Console.WriteLine($"{i}. {goal.GetStringRepresentation()}");
            i++;
        }
        Console.Write("Press any key return ");
        Console.ReadLine();
    }
    public void CreateGoal(){
        string choice;
        string name;
        string description;
        string points;
        int target;
        int bonus;

        Console.Clear();

        Console.WriteLine("The types of goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        choice = Console.ReadLine();
        switch(choice) {
            
            case "1":
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with the goal? ");
                points = Console.ReadLine();

                SimpleGoal sGoal = new SimpleGoal(name, description, points);
                _goals.Add(sGoal);
                break;

            case "2":
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with the goal? ");
                points = Console.ReadLine();

                EternalGoal eGoal = new EternalGoal(name, description, points);
                _goals.Add(eGoal);
                break;

            case "3":
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with the goal? ");
                points = Console.ReadLine();
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                target = Int32.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                bonus = Int32.Parse(Console.ReadLine());

                ChecklistGoal cGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(cGoal);
                break;
                
            default:
                break;
        }
    }

    public void AddExp() {
        _level+=0.25;
        if(_level!=0 && _level%1==0) {
            Console.Clear();
            Console.Write("You leveled up! ");
            Console.ReadLine();
        }
    }
    public void RecordEvent(int index){
        try {
        _goals[index-1].RecordEvent();
        _score += _goals[index-1].GetPoints(); 
        } catch (Exception e) {
            Console.WriteLine("Something went wrong");
        }
        AddExp();
    }
    public void SaveGoals(){
        string filename = "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename)) {
            outputFile.WriteLine($"{_score}:{_level}");
            foreach(Goal goal in _goals) {
                outputFile.WriteLine(goal.getSaveFormatData());
            }
        }

        Console.Clear();
        Console.Write("Successfuly Saved Goals");
        Console.ReadLine();
    }
    public void LoadGoals(){
        string filename = "goals.txt";
        string[] allGoals = System.IO.File.ReadAllLines(filename);

        _goals.Clear();

        string[] userData = allGoals[0].Split(":");
        _score = Int32.Parse(userData[0]);
        _level = Double.Parse(userData[1]);

        allGoals = allGoals.Skip(1).ToArray();

        foreach(String goal_details in allGoals) {
            string[] goal_data = goal_details.Split(":");

            string name = goal_data[1];
            string description = goal_data[2];
            string points = goal_data[3];

            switch (goal_data[0]) {
                case "SimpleGoal":
                    bool IsComplete = Boolean.Parse(goal_data[4]);

                    _goals.Add(new SimpleGoal(name, description, points));
                    if(IsComplete){_goals[_goals.Count-1].RecordEvent();}
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;

                case "ChecklistGoal":
                    int amountCompleted = Int32.Parse(goal_data[4]);
                    int target = Int32.Parse(goal_data[5]);
                    int bonus = Int32.Parse(goal_data[6]);

                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    for(int i = 1;i <=amountCompleted;i++){_goals[_goals.Count-1].RecordEvent();}
                    break;
                    
            }
        }
        Console.Clear();
        Console.Write("Successfuly Loaded Goals");
        Console.ReadLine();
    }
}