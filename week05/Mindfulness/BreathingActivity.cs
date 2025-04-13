using System.Data;

public class BreathingActivity : Activity{

    //constructor
    public BreathingActivity() : base("Welcome to the Breathing Activity.",
        "This activity will help you by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."){
        }

    public void Run(){
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime){
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}