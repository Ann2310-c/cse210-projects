//Showing Creativity: I add a list with different scriptures and the program choose random.
using System;

class Program
{
    static void Main(string[] args) //the first executed
    {
        //Reference is a class / reference the object / new Reference calls the constructor of the Reference class to initialize the object.
        //Reference reference = new Reference("Proverbs", 3, 5, 6);
        //Scripture scripture = new Scripture(reference, 
            ///"Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");
        
        //list of Scriptures
        List<Scripture> scriptures = new List<Scripture>{
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("John", 14, 27), "Peace I leave with you; my peace I give you. I do not give to you as the world gives. Do not let your hearts be troubled and do not be afraid."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing."),
        };

        //Select random scripture
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        //main loop
        while (true){
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            
            scripture.HideRandomWords(3);
            
            if (scripture.IsCompletelyHidden()){
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}