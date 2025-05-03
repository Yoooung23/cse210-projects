using System;

class Program
{
    static void Main(string[] args)
    {
        //loops!!!
            //while
            string response = "no";

            while (response == "no")
            {
                Console.Write("Do you want to end? (yes/no): ");
                response = Console.ReadLine();
            }
            // //do-while
            string reply;
            do
            {
                Console.Write("Do you like pizza? ");
                reply = Console.ReadLine();
            } while (reply == "yes");
            
            //for
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //for-each
            List<string> colors = new List<string> { "red", "blue", "red", "blue", "green", "red", "blue" };

            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }

    }
}