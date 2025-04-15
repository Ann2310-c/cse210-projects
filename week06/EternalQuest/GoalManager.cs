public class GoalManager{

    private List<Goal> _goals;
    private int _score;

    //constructor
    public GoalManager(){
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start(){
        int choice;
        do{
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
            } DisplayPlayerInfo();
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

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter the points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice){
            case 1:
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case 3:
                Console.Write("Enter the target times: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    public void ListGoalDetails(){
        Console.WriteLine("\nYour goals:");
        int i = 1;
        foreach (Goal goal in _goals){
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void RecordEvent(){
        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++){
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        _goals[goalIndex].RecordEvent();

        _score += _goals[goalIndex].GetPoints();
    }

    public void SaveGoals(){
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename)){
            writer.WriteLine(_score);

            foreach (Goal goal in _goals){
                writer.WriteLine(goal.GetStringRepresentation());
            }

        } Console.WriteLine("Goals saved!");
    }

    public void LoadGoals(){
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename)){
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "SimpleGoal"){
                    bool complete = bool.Parse(parts[4]);
                    SimpleGoal sg = new SimpleGoal(name, desc, points);
                    _goals.Add(sg);
                }
                else if (type == "EternalGoal"){
                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal"){
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int done = int.Parse(parts[6]);
                    ChecklistGoal cg = new ChecklistGoal(name, desc, points, target, bonus);
                    _goals.Add(cg);
                }
            }Console.WriteLine("Goals loaded!");
        }
        else{
            Console.WriteLine("File not found.");
        }
    }
}
