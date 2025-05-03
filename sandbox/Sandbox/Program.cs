using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> animals = new List<string>();
        List<int> debits = new List<int>();

        animals.Add("Cow");
        animals.Add("Horse");
        animals.Add("Chicken");
        animals.Add("Monkey");
       
       foreach (string animal in animals)
       {
        Console.WriteLine(animal);
       }

       int AddNumbers(int a, int b)
       {
        int sum = a + b;
        return sum;
       }
       Console.WriteLine(AddNumbers(1, 2));
    }
}