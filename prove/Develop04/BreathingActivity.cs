class BreathingActivity : Activity {

    private List<string> _breathingAnimationFrames = new List<string>();

    public BreathingActivity() {
        _name = "Breathing activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

        _breathingAnimationFrames.Add(".");
        _breathingAnimationFrames.Add("o");
        _breathingAnimationFrames.Add("O");

    }

    public void Run() {
        DisplayStartingMessage();
        _duration = Int32.Parse(Console.ReadLine());
        
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        bool breathIn = true;
        int sectionDuration = 3; 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime){
            if(breathIn) {
                Console.Write($"Breath in...  ");
                ShowBreathingAnimation(sectionDuration, breathIn);
                breathIn = false;
            } else {
                Console.Write($"Breath out...  ");
                ShowBreathingAnimation(sectionDuration, breathIn);
                breathIn = true;
            }
        }
        Console.Clear();
        DisplaEndingMessage();
    }

    public void ShowBreathingAnimation(int seconds, bool breathIn) {
        int i = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime){
            if(breathIn) {
                Console.Write(_breathingAnimationFrames[i]);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                i = i<_breathingAnimationFrames.Count-1?i+1:i;
            } else {
                Console.Write(_breathingAnimationFrames[2]);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Console.Write(_breathingAnimationFrames[1]);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Console.Write(_breathingAnimationFrames[0]);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                i = i>0 ? i-1 : i;
            }
        }
        Console.WriteLine("\b \b");
    }
}