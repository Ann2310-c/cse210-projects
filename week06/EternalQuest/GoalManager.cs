public class GoalManager{
    private List<Goal> _goals;
    private int _score;

    public GoalManager(){
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start(){
        int choice;
        do
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice){
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
            }
            DisplayPlayerInfo();
        } while (choice != 6);
    }

    public void DisplayPlayerInfo(){
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void CreateGoal(){
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice){
            case 1:
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    public void ListGoalDetails(){
        Console.WriteLine("\nYour goals:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void RecordEvent(){
        Console.Write("Enter the number of the goal: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[goalIndex];
        goal.RecordEvent();

        string[] parts = goal.GetStringRepresentation().Split('|');
        int points = int.Parse(parts[3]);
        int bonus = 0;

        if (goal is ChecklistGoal && goal.IsComplete()){
            bonus = int.Parse(parts[6]);
        }

        int total = points + bonus;
        _score += total;

        Console.WriteLine($"Congratulations! You have earned {total} points!");

        string[] messages = {
            "Great job!",
            "You're doing amazing!",
            "Keep up the good work!",
            "Another goal crushed!",
            "You're unstoppable!"
        };

        Random random = new Random();
        int index = random.Next(messages.Length);
        Console.WriteLine(messages[index]);
    }


    public void SaveGoals(){
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename)){
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals){
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(){
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename)){
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split('|');
                string goalType = parts[0];

                if (goalType == "SimpleGoal"){
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    
                    if (isComplete) goal.RecordEvent(); 

                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal"){
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal"){
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);

                    for (int j = 0; j < amountCompleted; j++){
                        goal.RecordEvent();
                    }

                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else{
            Console.WriteLine("File not found.");
        }
    }
}


