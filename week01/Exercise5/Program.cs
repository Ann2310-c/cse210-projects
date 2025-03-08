using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNum = PromptUserNumber();
        int squareNum = SquareNumber(userNum);
        DisplayResult(userName, squareNum);

        //DisplayWelcome
        static void DisplayWelcome(){
            Console.WriteLine("Welcome to the program!");
        }

        //PromptUserName
        static string PromptUserName(){
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        //PromptUserNumber
        static int PromptUserNumber(){
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        //SquareNumber
        static int SquareNumber(int number){
            int square = number * number;
            return square;
        }

        //DisplayResult
        static void DisplayResult(string name, int square){
            Console.Write($"{name}, the square of your number is {square}");
        }
    }
}