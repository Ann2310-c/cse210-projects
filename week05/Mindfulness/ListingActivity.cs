public class ListingActivity : Activity {
    private int _count;
    private List<string> _prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Welcome to the Listing Activity.",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."){
        }

    public void Run(){
        DisplayStartingMessage();
        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        ShowSpinner(5);

        Console.WriteLine("You may begin in:");
        List<string> items = GetListFromUser();

        _count = items.Count;

        Console.WriteLine($"You listed {_count} items!.");
        ShowSpinner(3);
        DisplayEndingMessage();
    }

    private void GetRandomPrompt(){
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine($" --- {_prompts[index]} ---");
    }

    private List<string> GetListFromUser(){
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while(DateTime.Now < endTime){
            Console.Write("> ");
            string item = Console.ReadLine();
            items.Add(item);
        }
        return items;
    }
}