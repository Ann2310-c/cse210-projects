using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        int breathingCount = 0;
        int listingCount = 0;
        int reflectingCount = 0;

        int choice = 0;
        while (choice != 4){
            Console.Clear();
            Console.WriteLine("=== Menu Options ===");
             Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            switch(choice){
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;
                
                case 2:
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    reflectingCount++;
                    break;

                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case 4:
                    Console.WriteLine($"\nSession Summary:");
                    Console.WriteLine($"Breathing Activities: {breathingCount}");
                    Console.WriteLine($"Reflecting Activities: {reflectingCount}");
                    Console.WriteLine($"Listing Activities: {listingCount}");
                    Console.WriteLine("THANKS!!! bye bye <3");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }
}