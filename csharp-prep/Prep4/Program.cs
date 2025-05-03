using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter a number, type 0 if finished: ");
            int reply; 

            if (int.TryParse(Console.ReadLine(), out reply))
            {
                if (reply == 0)
                {
                    Console.WriteLine("Your list is: ");
                    foreach (int num in numbers)
                    {
                        Console.WriteLine(num);
                    }
                    Console.WriteLine("Thanks! See ya sukkah!");
                    break;
                } 
            }
            numbers.Add(reply);
        }
    }
}