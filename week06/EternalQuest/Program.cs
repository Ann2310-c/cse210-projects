using System;
//Creativity: I add a list of motivational words and randomly chose one.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}