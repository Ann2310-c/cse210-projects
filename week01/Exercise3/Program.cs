using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int userNumber = 0;

        while (userNumber != magicNumber){
            Console.Write("What is your guess? ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber == magicNumber){
                Console.WriteLine("You guessed it!");
            }
            else if(userNumber > magicNumber){
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine("Higher");
            }
        }
    }
}