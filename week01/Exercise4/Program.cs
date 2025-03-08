using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNum = -1;

        do{
            Console.Write("Enter number: ");
            userNum = int.Parse(Console.ReadLine());

            if (userNum != 0){
                numbers.Add(userNum);
            } 
        }while (userNum != 0);
        
        //Console.WriteLine(string.Join(", ", numbers));

        //1.sum of the numbers
        int sum = 0;
        foreach(int number in numbers){
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        //2.average of the numbers
        float average = ((float)sum)/numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //3.maximun number
        int maximun = numbers[0];
        foreach(int number in numbers){
            if(number>maximun){
                maximun = number;
            }
        }
        Console.WriteLine($"The largest number is: {maximun}");

    }
}