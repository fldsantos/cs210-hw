class ReflectionActivity : Activity {

    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectionActivity() {
        _name = "Reflection activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        string[] allPrompts = System.IO.File.ReadAllLines("RefActPrompts.txt");
        string[] allQuestions = System.IO.File.ReadAllLines("RefActQuestions.txt");

        foreach (string prompt in allPrompts) {
            _prompts.Add(prompt);
        }

        foreach (string question in allQuestions) {
            _questions.Add(question);
        }
    }

    public void Run() {
        DisplayStartingMessage();
        _duration = Int32.Parse(Console.ReadLine());
        
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine("");

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue. ");
        Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in...  ");
        ShowCountDown(5);

        Console.Clear();

        int currentDuration = _duration;
        int singleQuestionDuration = 10;

        while (currentDuration > 0) {
            singleQuestionDuration = currentDuration<singleQuestionDuration?currentDuration:singleQuestionDuration;
            DisplayQuestions();
            ShowSpinner(singleQuestionDuration);

            currentDuration-=singleQuestionDuration;
        }

        Console.Clear();
        DisplaEndingMessage();
    }

    private string GetRandomPrompt() {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count-1)];
    }

    private string GetRandomQuestion() {
        Random rnd = new Random();
        return _questions[rnd.Next(_questions.Count-1)];
    }

    public void DisplayPrompt() {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("");
    }

    public void DisplayQuestions() {
        Console.Write($"> {GetRandomQuestion() }");
    }
}