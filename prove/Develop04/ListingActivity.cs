class ListingActivity : Activity {

    private int _count;
    private List<string> _prompts = new List<string>();
    private List<string> _responses = new List<string>();

    public ListingActivity() {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        string[] allPrompts = System.IO.File.ReadAllLines("ListActPrompts.txt");

        foreach (string prompt in allPrompts) {
            _prompts.Add(prompt);
        }
    }

    public void Run() {
        DisplayStartingMessage();
        _duration = Int32.Parse(Console.ReadLine());
        
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("Consider the following prompt: ");
        DisplayPrompt();
        Console.WriteLine("You may begin in...  ");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime){
            Console.Write("> "); 
            _responses.Add(Console.ReadLine());
            _count++;
        }
        Console.WriteLine("");
        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine("");
        DisplaEndingMessage();
    }

    public string GetRandomPrompt() {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count-1)];
    }

    public void DisplayPrompt() {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("");
    }

    public List<string> GetListFromUser() {
        return _responses;
    }
}