class Activity {

    protected string _name;
    protected string _description;
    protected int _duration;

    private List<string> _animationFrames = new List<string>();

    public Activity() {
        _animationFrames.Add("|");
        _animationFrames.Add("/");
        _animationFrames.Add("-");
        _animationFrames.Add("\\");
        _animationFrames.Add("|");
        _animationFrames.Add("/");
        _animationFrames.Add("-");
        _animationFrames.Add("\\");
    }

    public void DisplayStartingMessage() {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"");
        Console.WriteLine($"{_description}");
        Console.WriteLine($"");
        Console.Write($"How long, in seconds, would you like for your session? ");
    }

    public void DisplaEndingMessage() {
        Console.WriteLine("Well done!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds) {
        int i = 0;
        while(seconds > 0) {
            Console.Write(_animationFrames[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            seconds--;
            i=i>=_animationFrames.Count-1?i=0:i+1;
        }
        Console.WriteLine("\b \b");
    }

    public void ShowCountDown(int seconds) {
        while(seconds > 0) {
            Console.Write("\b \b");
            Console.Write(seconds);
            Thread.Sleep(1000);

            seconds--;
        }
        Console.WriteLine("\b \b");
    }
}