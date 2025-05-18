class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        journal.LoadFromFile("/Users/loganyoung/Documents/School/S25/CSE-210/cse210-projects/prove/Develop04/filename.json");

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("===== NEW JOURNAL ENTRY =====\n");
                    string date = DateTime.Now.ToString();
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}\n");
                    string response = Console.ReadLine();
                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    break;
                case "2":
                    Console.WriteLine("\n===== JOURNAL ENTRIES =====\n");
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile("/Users/loganyoung/Documents/School/S25/CSE-210/cse210-projects/prove/Develop04/filename.json");
                    running = false;
                    // Above and beyond. Positive  affirmation to spike dopamine, thereby reinforcing behavior and encouraging continued use.
                    Console.WriteLine("\n===== JOURNAL SAVED =====\n");
                    Console.WriteLine("You are a beutiful human being. Your thoughts and feelings are valid and worthy of expression. \nKeep writing, you bomm-digity magestic beast. \nBy the way, your hair is exquisite. New shoes?");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

    }

    static void DisplayMenu()
    {
        Console.WriteLine("===== JOURNAL MENU =====");
        Console.WriteLine("1. Add new entry");
        Console.WriteLine("2. Display all entries");
        Console.WriteLine("3. Save and quit");
        Console.Write("\nSelect an option: ");
    }
}